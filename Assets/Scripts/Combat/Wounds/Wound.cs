/// <summary>
/// Object. containing information about Wound and corresponding penalties, that Trooper got. 
/// </summary>
public class Wound
{
    #region Fields
    private WoundSeverity severity;

    private WoundEffect effect;

    private int woundPoints;
    #endregion

    /// <summary>
    /// Create a new wound with penalties, depending on it's Severity
    /// </summary>
    /// <param name="severity">Severity of the new wound</param>
    public Wound(WoundSeverity severity)
    {
        this.severity = severity;
        woundPoints = GetWoundPoints();
        effect = GetEffect();
    }

    #region Properties
    /// <summary>
    /// Severity of current Wound
    /// </summary>
    public WoundSeverity Severity
    {
        get => severity;
    }
    /// <summary>
    /// Trooper's efficiency area, which is affected by the Wound
    /// </summary>
    public WoundEffect Effect
    {
        get => effect;
    }
    /// <summary>
    /// Count of Wound points, that thw Wound adds to the Trooper's WOnd point pool
    /// and determing, how much the Wound affects Trooper's morale and combat efficiency
    /// </summary>
    public int WoundPoints
    {
        get => woundPoints;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Get coun of Wound points, deppends on current Wound Weverity
    /// </summary>
    /// <returns>Count of Wound point of the WOund</returns>
    private int GetWoundPoints()
    {
        return (int)severity;
    }
    /// <summary>
    /// Randmoply determine, which are of Efficiency will be affected by current Wound
    /// There can be no effect, if Severit of the WOund is minimal (Stun)
    /// </summary>
    /// <returns>Current wound Effect type</returns>
    private WoundEffect GetEffect()
    {
        if(severity > 0)
        {
            return (WoundEffect)Randomizer.Instance.GetRandomInt(1, 2);
        }
        else
        {
            return WoundEffect.None;
        }
    }
    #endregion
}

