/// <summary>
/// Singltone class for storing and adminstartting constants. 
/// CAUTION: constatnt values are included temporally, 
/// until the database is integrated into app
/// </summary>
public class ValuesStorage
{
    #region Fields
    private static ValuesStorage instance;
    private WoundsValues woundValues = new WoundsValues();
    private RollMaxValues rollMaxValues = new RollMaxValues();
    private FirefightRangesValues firefightRangesValues = new FirefightRangesValues();
    private HitsValues hitsValues = new HitsValues();
    #endregion

    #region Properties
    /// <summary>
    /// Current singltone object of the ValuesStorage class
    /// </summary>
    public static ValuesStorage Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ValuesStorage();
            }
            return instance;
        }
    }
    #region Storage objects
    /// <summary>
    /// Current object, storing Wound values constants 
    /// </summary>
    public WoundsValues WoundValues
    {
        get => woundValues;
    }
    /// <summary>
    /// Current object, storing Maximum value of the Light and Heavy rolls 
    /// </summary>
    public RollMaxValues RollMaxValues
    {
        get => rollMaxValues;
    }
    /// <summary>
    /// Current object, storing values in meters (units) to measure Distance states
    /// </summary>
    public FirefightRangesValues FirefightRangesValues
    {
        get => firefightRangesValues;
    }
    /// <summary>
    /// Current object, storing rolls values, needed to get different results of the Attack hit
    /// </summary>
    public HitsValues HitsValues
    {
        get => hitsValues;
    }
    #endregion
    #endregion
}
