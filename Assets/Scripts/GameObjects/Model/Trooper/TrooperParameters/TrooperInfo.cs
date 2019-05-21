/// <summary>
/// Object,s toring base info about a Trooper
/// </summary>
public class TrooperInfo
{
    private string name;
    private TrooperTier tier;

    /// <summary>
    /// New TrooperInfo object
    /// </summary>
    /// <param name="name">Trooper's name</param>
    /// <param name="tier">Trooper's Combat Tier</param>
    public TrooperInfo(string name = "Trooper", TrooperTier tier = TrooperTier.Rookie)
    {
        this.name = name;
        this.tier = tier;
    }

    /// <summary>
    /// Trooper's name
    /// </summary>
    public string Name
    {
        get => name;
    }
    /// <summary>
    /// Trooper's combat experience tier
    /// </summary>
    public TrooperTier Tier
    {
        get => tier;
    }
}
