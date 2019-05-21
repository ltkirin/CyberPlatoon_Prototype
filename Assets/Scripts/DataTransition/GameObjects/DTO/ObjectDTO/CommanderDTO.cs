using Newtonsoft.Json;

/// <summary>
/// Data object to transfer Commander's data
/// </summary>
[JsonObject]
public class CommanderDTO
{
    private int commanderTier;
    private string[] orderNames;
    private TrooperInfoDTO info;
    private TrooperStaticticsDTO statictics;
    private WeaponDTO[] weapons;
    private int armorType;
    /// <summary>
    /// Trooper base info
    /// </summary>
    [JsonProperty]
    public TrooperInfoDTO Info
    {
        get => info;
        set => info = value;
    }
    /// <summary>
    /// Trooper phisical stats
    /// </summary>
    [JsonProperty]
    public TrooperStaticticsDTO Statictics
    {
        get => statictics;
        set => statictics = value;
    }
    /// <summary>
    /// Trooper's weapon loadout
    /// </summary>
    [JsonProperty]
    public WeaponDTO[] Weapons
    {
        get => weapons;
        set => weapons = value;
    }
    /// <summary>
    /// Trooper armor type (0 = None, 1 = Light, 2 = Heavy)
    /// </summary>
    [JsonProperty]
    public int ArmorType
    {
        get => armorType;
        set => armorType = value;
    }
    /// <summary>
    /// Index of the Commander place in a Platoon comman line (0 = Squad leader, 1 = Platoon leader)
    /// </summary>
    [JsonProperty]
    public int CommanderTier
    {
        get => commanderTier;
        set => commanderTier = value;
    }
    /// <summary>
    /// Names of Orders, that the Commander can issue to his subordinates
    /// </summary>
    [JsonProperty]
    public string[] OrderNames
    {
        get => orderNames;
        set => orderNames = value;
    }
}
