/// <summary>
/// Class, containing constant values of Range stages in meters (units)
/// CAUTION: constatnt values are included temporally, 
/// until the database is integrated into app
/// </summary>
public class FirefightRangesValues
{
    #region Fields
    private int close = 50;
    private int medium = 100;
    private int high = 150;
    private int extreme = 200;
    #endregion

    #region Properties
    /// <summary>
    /// Minimal range to operate, allows to use full Attacks pool 
    /// </summary>
    public int Close
    {
        get => close;
    }
    /// <summary>
    /// Medium range to operate, provides minor penalty to Rate of fire
    /// </summary>
    public int Medium
    {
        get => medium;
    }
    /// <summary>
    /// Long range to operate, provides medium penalty to Rate of fire
    /// </summary>
    public int High
    {
        get => high;
    }
    /// <summary>
    /// Medium range to operate, provides major penalty to Rate of fire
    /// </summary>
    public int Extreme
    {
        get => extreme;
    }
    #endregion
}
