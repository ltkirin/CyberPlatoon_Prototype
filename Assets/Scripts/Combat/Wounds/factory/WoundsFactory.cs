/// <summary>
/// Static Wounds factory, creating Wounds for every Trooper in a game session
/// </summary>
public static class WoundsFactory
{
    /// <summary>
    /// Create a wound, with  severity, deppending on To Wound roll result
    /// </summary>
    /// <param name="woundRollResult">To Woubd roll result</param>
    /// <returns>A new wound</returns>
   public static Wound GetWound(int woundRollResult)
    {
        WoundSeverity severity;
        if(woundRollResult >= ValuesStorage.Instance.WoundValues.StunnedValue)
        {
            severity = WoundSeverity.Stun;
        }
        else if(woundRollResult >= ValuesStorage.Instance.WoundValues.LightWoundValue)
        {
            severity = WoundSeverity.Light;
        }
        else 
        {
            severity = WoundSeverity.Heavy;
        }
        return new Wound(severity);
    }
}
