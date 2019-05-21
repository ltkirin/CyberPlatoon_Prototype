/// <summary>
/// Enum, defining which negative effects Trooper gets by the wound
/// </summary>
public enum WoundEffect
{
    /// <summary>
    /// Wond does not give any negative modifiers, it's just a scratch
    /// </summary>
    None = 0,
    /// <summary>
    /// Wound affected combat abilities of the Trooper, redicng his Accuracy
    /// </summary>
    Combat = 1,
    /// <summary>
    /// Injury affected movement allowance of a Trooper and slowing his movement down
    /// </summary>
    Mobility = 2
}
