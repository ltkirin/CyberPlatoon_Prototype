using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Object to proceed attacks from Attacking unit to Defending
/// </summary>
public class Firefight
{
    #region Fields
    /// <summary>
    /// Attacking unit
    /// </summary>
    private readonly FireteamModel attacker;
    /// <summary>
    /// Defending unit
    /// </summary>
    private FireteamModel target;
    /// <summary>
    /// Pool of Attacks, used in current Firefight
    /// </summary>
    private List<Attack> firefightAttacks;
    /// <summary>
    /// Range type of the Firefight distance
    /// </summary>
    private FirefightRange range;
    /// <summary>
    /// Dicitionary,contiainig count of the Misses, Suppressing hits and Wound hits, resolved by current Firefight
    /// </summary>
    private Dictionary<string, int> firefightResults = new Dictionary<string, int>()
    {
        {"Misses",0},
        {"Suppressing hits", 0},
        {"Wounds",0 }
    };
    #endregion

    /// <summary>
    /// Create new Firefight for current Attacker
    /// </summary>
    /// <param name="attacker">Attacking Unit</param>
    public Firefight(FireteamModel attacker)
    {
        this.attacker = attacker;
    }

    #region Methods
    /// <summary>
    /// Resolve Attack at the Target unit.
    /// </summary>
    /// <param name="target">Unit to attck</param>
    /// <param name="distance">Distance between the Attacker an the Defender</param>
    public void Resolve(FireteamModel target, float distance)
    {
        this.target = target;
        range = GetRange(distance);
        PlayFirefight();
        ResetFirefight();
    }
    /// <summary>
    /// Process and use all the involved in currnt Firefight Attacks
    /// </summary>
    private void PlayFirefight()
    {
        firefightAttacks = GetFirefightAttacks();
        int[] results = GetAttacksResults(firefightAttacks);
        GetFirefightResults(results);
        target.ApplyDamage(firefightResults["Suppressing hits"], firefightResults["Wounds"]);
    }
    /// <summary>
    /// Fill the FireFight Results dictionry by quantity of different Attacks results
    /// </summary>
    /// <param name="attacksResults">Collection of the results of resolved Attacks</param>
    private void GetFirefightResults(IList<int> attacksResults)
    {
        firefightResults["Misses"] = attacksResults.Where(i => i <= ValuesStorage.Instance.HitsValues.Miss).Count();
        firefightResults["Suppressing hits"] = attacksResults.Where(i => i > ValuesStorage.Instance.HitsValues.Miss
        && i <= ValuesStorage.Instance.HitsValues.Supressed).Count();
        firefightResults["Wounds"] = attacksResults.Where(i => i > ValuesStorage.Instance.HitsValues.Supressed).Count();
    }
    /// <summary>
    /// Method to get th Distance type from Distance between Attacker and Defender 
    /// </summary>
    /// <param name="distance">Distance between the Firefight participators</param>
    /// <returns>range type of the Firefight</returns>
    private FirefightRange GetRange(float distance)
    {
        FirefightRange actualRange;
        if (distance >= ValuesStorage.Instance.FirefightRangesValues.Extreme)
        {
            actualRange = FirefightRange.Extreme;
        }
        else if (distance >= ValuesStorage.Instance.FirefightRangesValues.High)
        {
            actualRange = FirefightRange.Long;
        }
        else if (distance >= ValuesStorage.Instance.FirefightRangesValues.Medium)
        {
            actualRange = FirefightRange.Medium;
        }
        else
        {
            actualRange = FirefightRange.Close;
        }
        return actualRange;
    }
    /// <summary>
    /// Get Attack Pool, used in current Firefight
    /// </summary>
    /// <returns>Pool of used in current Firefight</returns>
    private List<Attack> GetFirefightAttacks()
    {
        return attacker.GetAttacks(range);
    }
    /// <summary>
    /// Method to resolve Attacks, used in current Firefight and get attacks results
    /// </summary>
    /// <param name="attacks">Collection of Attacks to inflict</param>
    /// <returns>Collection of Attacks results for current Firefight</returns>
    private int[] GetAttacksResults(IList<Attack> attacks)
    {
        return firefightAttacks.Select(a => GetAttackResult(a)).ToArray();
    }
    /// <summary>
    /// Get result of current Attack
    /// </summary>
    /// <param name="attack">Attack to resolve</param>
    /// <returns>Result of the resolver Attack</returns>
    private int GetAttackResult(Attack attack)
    {
        if (target.Armor > 0)
        {
            int armorModifier = GetArmorModifier(target, attack);
            attack.UpdateModifier(armorModifier);
        }

        int result = 0;
        int maxRollValue = GetMaxAttackRollValue(attack.Type);
        if (attack.RerollRanges.Any())
        {
            if (attack.RerollRanges.Contains(range))
            {
                result = Randomizer.Instance.GetMaxReroll(maxRollValue);
            }
        }
        else
        {
            result = Randomizer.Instance.GetRoll(maxRollValue);
        }
        attack.ResetAttack();
        return result;

    }
    /// <summary>
    /// Method to get maximum value of the Attack To Hit roll (Light or heavy type)
    /// </summary>
    /// <param name="type">Type of the attack</param>
    /// <returns>Maximum value of the To Hit pure roll</returns>
    private int GetMaxAttackRollValue(RollType type)
    {
        int value;
        if (type == RollType.Light)
        {
            value = ValuesStorage.Instance.RollMaxValues.Light;
        }
        else
        {
            value = ValuesStorage.Instance.RollMaxValues.Heavy;
        }
        return value;
    }
    /// <summary>
    /// Gets actual ToHit modifier of the Attack, according to the Armor value of the target and the Armor piercing of the Attack
    /// </summary>
    /// <param name="target">Target of the Attack</param>
    /// <param name="attack">Attack to modify</param>
    /// <returns>Actual armor ToHit modifier for Current Attack to the Current Target</returns>
    private int GetArmorModifier(FireteamModel target, Attack attack)
    {
        int modifier = 0;
        int targetArmor = target.Armor;
        int attackArmorPiersing = attack.ArmorPiersing;
        if (attackArmorPiersing < targetArmor)
        {
            modifier = -(targetArmor - attackArmorPiersing);
        }

        return modifier;

    }
    /// <summary>
    /// Reset all values to default after resolving all Attacks and inflicting damage to the target.
    /// </summary>
    private void ResetFirefight()
    {
        target = null;
        firefightResults["Misses"] = 0;
        firefightResults["Suppressing hits"] = 0;
        firefightResults["Wounds"] = 0;
        firefightAttacks.Clear();
    }
    /// <summary>
    /// Full info on current turn of the Firefight using, or between turns
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        string description;
        if (target != null)
        {
            description = $"Owner: {attacker.Name} || Defender: {target.Name}.\n" +
            $"Totaly shots made: {firefightAttacks.Count()}\n" +
            $"Misses: {firefightResults["Misses"]} || Suppressing hits {firefightResults["Suppressing hits"]} || Wounds: {firefightResults["Wounds"]}";
        }
        else
        {
            description = $"Owner: {attacker.Name}. Currently Firefight not in use";
        }
        return description;
    }
    #endregion
}
