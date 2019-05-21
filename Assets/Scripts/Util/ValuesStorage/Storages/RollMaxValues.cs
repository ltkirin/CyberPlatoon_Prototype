/// <summary>
/// Class, containing constant values of maximum values of pure roll for Light and Heavy rolls
/// CAUTION: constatnt values are included temporally, 
/// until the database is integrated into app
/// </summary>
public class RollMaxValues
{
    #region Fields
    private int light = 6;
    private int heavy = 10;
    #endregion

    #region Properties
    /// <summary>
    /// Maximum point of unmodified Light roll
    /// </summary>
    public int Light
    {
        get => light;
    }
    /// <summary>
    /// Maximum point of unmodified Heavy roll
    /// </summary>
    public int Heavy
    {
        get => heavy;
    }
    #endregion
}
