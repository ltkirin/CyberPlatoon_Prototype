using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Class to pass Attack paramaters during Firefight
/// </summary>
public class Attack
{
    #region fields
    private RollType type;
    /// <summary>
    /// Base modifier of To Hit check of the Attack
    /// </summary>
    private int baseAttackmodifier;
    private int currentAttackModifier;
    private List<FirefightRange> rerollRanges;
    private List<FirefightRange> usedRanges;
    private int armorPiersing;
    #endregion

    /// <summary>
    /// Crate new instance of Attack
    /// </summary>
    /// <param name="type">Damage type</param>
    /// <param name="baseAttackmodifier">Attack modifier of the Weapon, storing Attack</param>
    /// <param name="rerollRanges">Ranges, on witch Attack result can be rerolled</param>
    /// <param name="rollsQuantity"></param>
    /// <param name="armorPiersing"></param>
    public Attack(RollType type, int baseAttackmodifier, IList<FirefightRange> rerollRanges, IList<FirefightRange> usedRanges, int armorPiersing)
    {
        this.type = type;
        this.baseAttackmodifier = baseAttackmodifier;
        this.rerollRanges = rerollRanges.ToList();
        this.armorPiersing = armorPiersing;
        ResetAttack();
    }

    #region Properties
    /// <summary>
    /// Damage type of the Attack (Light or Heavy)
    /// </summary>
    public RollType Type
    {
        get => type;
    }
    /// <summary>
    /// Actual attack modifier. Is infliected on all stages of making Attack
    /// </summary>
    public int CurrentAttackModifier
    {
        get => currentAttackModifier;
    }
    /// <summary>
    /// Ranges, on whitch the Attack result can be rerolled
    /// </summary>
    public List<FirefightRange> RerollRanges
    {
        get => rerollRanges;
    }
    /// <summary>
    /// Possibility of the Attack to pass through Armor, provided by Covers and Vehicle Armor
    /// </summary>
    public int ArmorPiersing
    {
        get => armorPiersing;
    }
    /// <summary>
    /// Ranges, that weapon can cover (mostly can cover all ranges)
    /// </summary>
    public List<FirefightRange> UsedRanges
    {
        get => usedRanges;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Update modifier of the Attack by amunt on another stage of the Firefight
    /// </summary>
    /// <param name="amount">Amount to increase (or to decrease) current ToHit modifier on</param>
    public void UpdateModifier(int amount)
    {
        currentAttackModifier += amount;
    }
    /// <summary>
    /// Reset attack after making it and returning it into weapon Attacks Pool for the next use
    /// </summary>
    public void ResetAttack()
    {
        currentAttackModifier = baseAttackmodifier;
    }
    #endregion
}
