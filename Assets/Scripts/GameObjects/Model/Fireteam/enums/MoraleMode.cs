/// <summary>
/// Morale status of a Unit, defining, which Orders it can recieve 
/// </summary>
public enum MoraleStatus
{
    /// <summary>
    /// unit is fully demoralizedand can't execut any actions    
    /// </summary>
    Broken = 0,
    /// <summary>
    /// Unit can perform Defending and Retreating actions
    /// </summary>
    Low = 1,
    /// <summary>
    /// Unit can perform Defending, Retreating and Tactical actions
    /// </summary>
    Medium = 2,
    /// <summary>
    /// Unit can perform all types of actions, including Offensive
    /// </summary>
    High = 3
}
