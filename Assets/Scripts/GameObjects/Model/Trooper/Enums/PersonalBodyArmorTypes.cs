/// <summary>
/// Types of personal body armor, Trooper can carry
/// </summary>
public enum PersonalBodyArmorType 
{
    /// <summary>
    /// Trooper is unarmored (no bonus to Save check)
    /// </summary>
    None = 0,
    /// <summary>
    /// Trooper wearing light, mesh armour (minor bonus to the Save check)
    /// </summary>
    Light = 1,
    /// <summary>
    /// Trooper wearing heavy metal, ceramics or composite armor (major bonus to the Save check)
    /// </summary>
    Heavy = 2
}
