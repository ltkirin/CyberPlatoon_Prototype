/// <summary>
/// CAUTION: constatnt values are included temporally, 
/// until the database is integrated into app
/// </summary>
public class HitsValues
{
    #region Fields
    private int miss = 2;
    private int supressed = 5;
    private int wounded = 6;
    #endregion

    #region Properties
    /// <summary>
    /// Maximum roll result, providing failing to hit target
    /// </summary>
    public int Miss
    {
        get => miss;
    }
    /// <summary>
    /// Maximum roll result, providing hit near the target and Suppressing it with fire
    /// </summary>
    public int Supressed
    {
        get => supressed;
    }
    /// <summary>
    /// Minmal roll result, needed to directly hit the enemy and injure him
    /// </summary>
    public int Wounded
    {
        get => wounded;
    }
    #endregion
}
