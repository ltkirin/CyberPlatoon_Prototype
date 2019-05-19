/// <summary>
/// Static util to get enums by int Values
/// </summary>
public static class EnumConverter
{
    /// <summary>
    /// Convert int value into WeaponType enum
    /// </summary>
    /// <param name="value">Value to convert</param>
    /// <returns></returns>
    public static WeaponType GetWeaponType(int value)
    {
        return (WeaponType)value;
    }
    /// <summary>
    /// Convert int value into RollType enum
    /// </summary>
    /// <param name="value">Value to convert</param>
    /// <returns></returns>
    public static RollType GetAttackType(int value)
    {
        return (RollType)value;
    }
    /// <summary>
    /// Convert int value into RollType enum
    /// </summary>
    /// <param name="value">Value to convert</param>
    /// <returns></returns>
    public static FirefightRange GetFirefightRange(int value)
    {
        return (FirefightRange)value;
    }
}
