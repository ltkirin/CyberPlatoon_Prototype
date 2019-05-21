/// <summary>
/// Enum, representing, how bad a wound is
/// </summary>
public enum WoundSeverity
{
    /// <summary>
    /// No serious injury, Trooper is just stunned for several second (one turn per wound)
    /// </summary>
    Stun = 0,
    /// <summary>
    /// Minor injury, allowing to stay in action, but lowering combat abilities of a Trooper
    /// </summary>
    Light = 1,
    /// <summary>
    /// Major injury, which does not lowiring combat abilities of a Trooper 
    /// seriously, but also is a life threatening one 
    /// </summary>
    Heavy = 2
}
