/// <summary>
/// Object, creating Weapon Models from Weapon data objects
/// </summary>
public class WeaponsFactory
{
    /// <summary>
    /// Create a new weapon from Weapon data object
    /// </summary>
    /// <param name="weaponData">Weapon data object</param>
    /// <returns></returns>
    public WeaponModel CreateWeapon(WeaponDTO weaponData)
    {
        return new WeaponModel(weaponData.Name,
            EnumConverter.GetWeaponType(weaponData.Type),
            EnumConverter.GetAttackType(weaponData.Type),
            weaponData.RateOfFire,
            weaponData.AttackModifier,
            weaponData.ArmorPiercing,
            GetFirefightRanges(weaponData.RerollRanges),
            GetFirefightRanges(weaponData.UsedRanges));
    }
    
    /// <summary>
    /// Convert collection of int values into collection of FirefightRange enums
    /// </summary>
    /// <param name="values">Values collection</param>
    /// <returns></returns>
    private FirefightRange[] GetFirefightRanges(int[] values)
    {
        FirefightRange[] ranges = new FirefightRange[values.Length];
        for (int i = 0; i < ranges.Length; i++)
        {
            ranges[i] = EnumConverter.GetFirefightRange(values[i]);
        }
        return ranges;
    }

}
