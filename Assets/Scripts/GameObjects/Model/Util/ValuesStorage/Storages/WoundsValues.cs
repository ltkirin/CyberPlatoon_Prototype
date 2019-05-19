/// <summary>
/// Class, containing constant values of rolls values, needed to get different Wound type
/// CAUTION: constatnt values are included temporally, 
/// until the database is integrated into app
/// </summary>
public class WoundsValues
{
    #region Fields
    private int stunnedValue = 6;
    private int lightWoundValue = 3;
    private int heavyWoundValue = 2;
    #endregion

    #region Properties
    /// <summary>
    /// Save check result, needed to get least serious injury
    /// </summary>
    public int StunnedValue
    {
        get => stunnedValue;
    }
    /// <summary>
    /// Save check result, needed to get light serious injury
    /// </summary>
    public int LightWoundValue
    {
        get => lightWoundValue;
    }
    /// <summary>
    /// Save check result, needed to get serious injury
    /// </summary>
    public int HeavyWoundValue
    {
        get => heavyWoundValue;
    }
    #endregion
}
