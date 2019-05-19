using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Model of the primary infaintry unit to operate with.
/// </summary>
public class FireteamModel
{
    #region Fields
    private string name;
    private List<TrooperModel> troopers;
    /// <summary>
    /// Current maximum value of the fireteam Morale
    /// </summary>
    private int maxMorale;
    private int stressPoints = 0;
    /// <summary>
    /// Quantity of Stress markers, Troopers can ignore beacuse of major combat experience
    /// </summary>
    private int tierMoralBonus;
    private MoraleStatus moraleStatus;
    private int armor;
    #endregion

    #region Properties
    /// <summary>
    /// Fireteam name
    /// </summary>
    public string Name
    {
        get => name;
    }
    /// <summary>
    /// Armor value, provided by Cover
    /// </summary>
    public int Armor
    {
        get => armor;
    }
    /// <summary>
    /// Current quantity of Stress Points, inflicted by enemy
    /// </summary>
    public int StressPoints
    {
        get => stressPoints;
    }
    /// <summary>
    /// Curremt morale state of the Fireteam
    /// </summary>
    public MoraleStatus MoraleStatus
    {
        get => moraleStatus;
    }
    /// <summary>
    /// Collection of the Troopers models, assigned to current Fireteam
    /// </summary>
    public List<TrooperModel> Troopers
    {
        get => troopers;
    }
    #endregion

    #region Methods

    /// <summary>
    /// Get all Attacks, which can be made by Fireteam Troopers, 
    /// according to current Range, and with all Trooper and Weapon Accuracy modifier
    /// </summary>
    /// <param name="range">Range between current fireteam and it's target</param>
    /// <returns>Fully modified and filled by needed attacks quantity</returns>
    public List<Attack> GetAttacks(FirefightRange range)
    {
        List<Attack> attacks = troopers.Where(t => t.Status.IsInvolvedInCombat)
            .SelectMany(a => a.GetTrooperAttacks(range))
            .Where(a => a.UsedRanges.Contains(range))
            .ToList();
        foreach (Attack attack in attacks)
        {
            attack.UpdateModifier(-stressPoints);
        }
        return attacks;
    }
    /// <summary>
    /// Add amount of the Stress points to Fireteam Stress Points collection
    /// </summary>
    /// <param name="amount">Amount of the stress points</param>
    public void TakeStress(int amount)
    {
        stressPoints += amount;
    }
    /// <summary>
    /// Remove troopers, who were killed after last Firefight, from the Fireteam
    /// </summary>
    private void RemoveDeadFromFireteam()
    {
        List<TrooperModel> deadTroopers = troopers.Where(t => !t.Status.IsAlive).ToList();
        if (deadTroopers.Any())
        {
            foreach (TrooperModel deadTrooper in deadTroopers)
            {
                troopers.Remove(deadTrooper);
            }
        }
    }

    #region Morale
    /// <summary>
    /// Method to get actual Morale status, accoring to the Stress points level 
    /// and Maximum possible Morale value of the fireteam
    /// </summary>
    /// <returns>Actual Morale status</returns>
    private MoraleStatus GetMoraleStatus()
    {
        MoraleStatus actualStatus;
        int moraleDiffernece = maxMorale - stressPoints;
        float moraleRatio = (float)moraleDiffernece / (float)maxMorale;
        if (moraleRatio >= .75)
        {
            actualStatus = MoraleStatus.High;
        }
        else if (moraleRatio >= .5)
        {
            actualStatus = MoraleStatus.Medium;
        }
        else if (moraleRatio >= .25)
        {
            actualStatus = MoraleStatus.Low;
        }
        else
        {
            actualStatus = MoraleStatus.Broken;
        }
        return actualStatus;

    }
    /// <summary>
    /// Get maximum value of the Morale scale of the Fireteam
    /// </summary>
    /// <returns></returns>
    private int GetMaxMorale()
    {
        return troopers.Select(t => t.Stats.Morale).Sum();
    }
    /// <summary>
    /// Get current amount of Stress points, which can be ingored by every Firefight
    /// </summary>
    /// <returns></returns>
    private int GetTierMoraleBonus()
    {
        return troopers.Select(t => (int)t.Info.Tier).Sum();
    }
    /// <summary>
    /// Set all Morale - related fields to actual values
    /// </summary>
    private void UpdateMorale()
    {
        maxMorale = GetMaxMorale();
        moraleStatus = GetMoraleStatus();
        tierMoralBonus = GetTierMoraleBonus();
    }
    #endregion

    #region Damage Applying
    /// <summary>
    /// Add Stress points and resolve Wounds, got by last Firefight 
    /// </summary>
    /// <param name="stressPointsQuantity">Count of the Stress points, 
    /// got by Fireteam at the last Firefight</param>
    /// <param name="woundsQuantity">Count of the Wound hits, 
    /// got by Fireteam at the last Firefight</param>
    public void ApplyDamage(int stressPointsQuantity, int woundsQuantity)
    {
        stressPointsQuantity += woundsQuantity - tierMoralBonus;
        if (stressPointsQuantity > 0)
        {
            TakeStress(stressPointsQuantity);
        }
        if (woundsQuantity > 0)
        {
            AllocateWounds(woundsQuantity);
        }
        RemoveDeadFromFireteam();
        UpdateMorale();
    }
    /// <summary>
    /// Allocate needed quantity of Wounds by Wonds allocation rules
    /// </summary>
    /// <param name="woundQuantity">Quantity of wounds</param>
    private void AllocateWounds(int woundQuantity)
    {
        int troopersCount = troopers.Count;
        while (woundQuantity >= troopersCount)
        {
            AllocateWounds(troopers);
            woundQuantity -= troopersCount;
        }
        if (woundQuantity > 0)
        {
            List<TrooperModel> randomTroopers = GetRandomTroopers(woundQuantity);
            AllocateWounds(randomTroopers);
        }
        RemoveDeadFromFireteam();
    }
    /// <summary>
    /// Allocate one wound to each of the Troopers from collection
    /// </summary>
    /// <param name="troopersToWound">Collection of Troopers to allocate Wounds</param>
    private void AllocateWounds(IList<TrooperModel> troopersToWound)
    {
        foreach (TrooperModel trooper in troopersToWound)
        {
            trooper.InflictWound();
        }
    }
    /// <summary>
    /// List of the random Troopers of current Fireteam. Used to allocate wounds, if their count is less, then Fireteam strength
    /// </summary>
    /// <param name="quantity">Needed quantity of troopers</param>
    /// <returns></returns>
    private List<TrooperModel> GetRandomTroopers(int quantity)
    {
        int randomTrooperIndex;
        int lastIndex = troopers.Count - 1;
        TrooperModel selectedTrooper;
        List<TrooperModel> randomTroopers = new List<TrooperModel>();
        while (randomTroopers.Count < quantity)
        {
            randomTrooperIndex = Randomizer.Instance.GetRandomInt(0, lastIndex);
            selectedTrooper = troopers[randomTrooperIndex];
            if (!randomTroopers.Contains(selectedTrooper))
            {
                randomTroopers.Add(selectedTrooper);
            }
        }
        return randomTroopers;
    }
    #endregion

    #endregion
}
