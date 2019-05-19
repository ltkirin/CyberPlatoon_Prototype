using System.Linq;
using System.Collections.Generic;
/// <summary>
/// Model of the infantry Trooper, Fireteam prticipant
/// </summary>
public class TrooperModel : CombatObject
{
    #region Fields
    protected TrooperInfo info;
    protected TrooperStatistics stats;
    protected TrooperStatus status = new TrooperStatus();
    protected readonly TrooperWeaponary weapons = new TrooperWeaponary();
    protected readonly List<Wound> wounds = new List<Wound>();
    protected readonly ImplantsCollection implants = new ImplantsCollection();
    protected PersonalBodyArmorType bodyArmor = PersonalBodyArmorType.None;
    #endregion

    #region Constructors
    public TrooperModel(Dictionary<string, object> parameters) : base(parameters)
    {
    }
    #endregion

    #region Properties
    /// <summary>
    /// Basic information about Trooper (Name, esperience level and etc.)
    /// </summary>
    public TrooperInfo Info
    {
        get => info;
    }
    /// <summary>
    /// Physical statistics of the Trooper
    /// </summary>
    public TrooperStatistics Stats
    {
        get => stats;
    }
    /// <summary>
    /// Statuses and temporal effects of the Trooper
    /// </summary>
    public TrooperStatus Status
    {
        get => status;
    }
    /// <summary>
    /// Weapons, that the Trooper carries on a Mission
    /// </summary>
    public TrooperWeaponary Weapons
    {
        get => weapons;
    }
    /// <summary>
    /// Currently inflicted to the Trooper Wounds
    /// </summary>
    public List<Wound> Wounds
    {
        get => wounds;
    }
    /// <summary>
    /// Cyber augmentations, installed in the Trooper
    /// </summary>
    public ImplantsCollection Implants
    {
        get => implants;
    }
    /// <summary>
    /// Body armor type, that Trooper wears on a Mission
    /// </summary>
    public PersonalBodyArmorType BodyArmor
    {
        get => bodyArmor;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Gets trooper Attack modifier, accoring to his skills, condition and other factors
    /// </summary>
    /// <returns>Actual personal Attack modifier</returns>
    public int GetActualTrooperAttackModifier()
    {
        int actualModifier = stats.Accuracy;
        actualModifier += wounds.Where(w => w.Effect == WoundEffect.Combat).Count();
        if (status.IsDazzled)
        {
            actualModifier += -1;
        }
        return actualModifier;
    }
    /// <summary>
    /// Gets pool of Trooper's attacks in current moment with use of his currently selected Weapon
    /// </summary>
    /// <param name="range">Range state between the Trooper and his target</param>
    /// <returns>Pool of attacs for current Firefight, provided by current Trooper</returns>
    public List<Attack> GetTrooperAttacks(FirefightRange range)
    {
        WeaponModel activeWeapn = weapons.Hands;
        List<Attack> trooperAttacks = new List<Attack>();
        int attacksQuantity = activeWeapn.RateOfFire - (int)range;
        if (attacksQuantity < 1)
        {
            attacksQuantity = 1;
        }
        while (attacksQuantity > 0)
        {
            Attack attack = activeWeapn.AttackPool[attacksQuantity - 1];
            attack.UpdateModifier(GetActualTrooperAttackModifier());
            trooperAttacks.Add(attack);
            attacksQuantity--;
        }
        return trooperAttacks;
    }
    /// <summary>
    /// Generate a Wound, according to the Troopers personal armor, 
    /// resolve it's effects and check, if Trooper suirvived the Wound.
    /// </summary>
    public void InflictWound()
    {
        int result;
        int rollMaximum = ValuesStorage.Instance.RollMaxValues.Light;
        if (bodyArmor != PersonalBodyArmorType.None)
        {
            if (bodyArmor == PersonalBodyArmorType.Heavy)
            {
                rollMaximum = ValuesStorage.Instance.RollMaxValues.Heavy;
            }

            result = Randomizer.Instance.GetMaxReroll(rollMaximum);
        }
        else
        {
            result = Randomizer.Instance.GetRoll(rollMaximum);
        }
        Wound wound = WoundsFactory.GetWound(result);
        CyberLimbs cyberLimbs = implants.GetImplantOfType(typeof(CyberLimbs)) as CyberLimbs;
        if (cyberLimbs != null)
        {
            if (cyberLimbs.WoundIsIgnorable(wound))
            {
                return;
            }
        }
        wounds.Add(wound);
        status.IsAlive = SurvivedWound();
    }
    /// <summary>
    /// Get total Wound points, that the Trooper allready suffered
    /// </summary>
    /// <returns>Total Woun point of current Trooper</returns>
    protected int GetTotalWoundPoints()
    {
        return wounds.Select(w => w.WoundPoints).Sum();
    }
    /// <summary>
    /// Check, if the Trooper survived inflicted wound
    /// </summary>
    /// <returns>True = survived, fals = dead</returns>
    protected bool SurvivedWound()
    {
        int saveRoll;
        int actualEndurance = stats.Endurance - GetTotalWoundPoints();
        if (actualEndurance < 1)
        {
            return false;
        }
        LifeSaverImplant lifesaver = implants.GetImplantOfType(typeof(LifeSaverImplant)) as LifeSaverImplant;
        if (lifesaver != null)
        {
            saveRoll = lifesaver.GetSaveCheck();
        }
        else
        {
            saveRoll = Randomizer.Instance.GetRoll(ValuesStorage.Instance.RollMaxValues.Light);
        }
        return saveRoll < actualEndurance;
    }
    /// <summary>
    /// Add a new weapon to Troopers Weaponary
    /// </summary>
    /// <param name="weapon">Weapon to add</param>
    public void PickUpWeapon(WeaponModel weapon)
    {
        weapons.PickUpWeapon(weapon);
    }
    /// <summary>
    /// Give a Trooper a full new Weapons Loadout (current load out will be lost)
    /// </summary>
    /// <param name="loadout">New loadout</param>
    public void PickUpLoadout(IList<WeaponModel> loadout)
    {
        weapons.PickUpLoadout(loadout);
    }
    #endregion
}
