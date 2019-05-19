using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Contains information about Weapon type 
/// /// </summary>
public class WeaponModel
{
    #region Fields
    private string name;
    private WeaponType type;
    /// <summary>
    /// Attack type - Light or Heavy caliber
    /// </summary>
    private RollType attackType;
    private int rateOfFire;
    /// <summary>
    /// Accuracy modifier of the Weapon
    /// </summary>
    private int attackModifier;
    /// <summary>
    /// Possibility of the Weapon to pierce through the Armor, provided by Covers and Vehicle Armor
    /// </summary>
    private int armorPiercing;
    /// <summary>
    /// Ranges, where resaults of Attacks of the Weapon can be rerolled
    /// </summary>
    private FirefightRange[] rerollRanges;
    private FirefightRange[] usedRanges;
    private List<Attack> attackPool;

    public WeaponModel(string name, WeaponType type, RollType attackType, 
        int rateOfFire, int attackModifier, int armorPiercing,
        IList<FirefightRange> rerollRanges, IList<FirefightRange> usedRanges)
    {
        this.name = name;
        this.type = type;
        this.attackType = attackType;
        this.rateOfFire = rateOfFire;
        this.attackModifier = attackModifier;
        this.armorPiercing = armorPiercing;
        this.rerollRanges = rerollRanges.ToArray();
        this.usedRanges = usedRanges.ToArray();
    }
    #endregion




    #region Properties
    /// <summary>
    /// Name of the Weapon
    /// </summary>
    public string Name
    {
        get => name;
    }
    /// <summary>
    /// Current weapon role
    /// </summary>
    public WeaponType Type
    {
        get => type;
    }
    /// <summary>
    /// Pool of Attack object (objects reusable)
    /// </summary>
    public List<Attack> AttackPool
    {
        get => attackPool;
    }
    /// <summary>
    /// Quantity of attacks, made by one Firefight
    /// </summary>
    public int RateOfFire
    {
        get => rateOfFire;
    }


    #endregion

    #region Methods
    /// <summary>
    /// Creates Attacks pool of the weapon
    /// </summary>
    /// <returns>Fully packed Attacs pool (all Attacks are reusable)</returns>
    public List<Attack> GetAttacksPool()
    {
        List<Attack> pool = new List<Attack>();
        for (int i = rateOfFire; i > 0; i--)
        {
            Attack newAttack = new Attack(attackType, attackModifier, rerollRanges, usedRanges, armorPiercing);
            pool.Add(newAttack);
        }
        return pool;
    }
    /// <summary>
    /// Gets the name of the Weapon
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return name;
    }
    #endregion
}
