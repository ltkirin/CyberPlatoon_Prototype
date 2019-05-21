using Newtonsoft.Json;
/// <summary>
/// Data transfer object for Trooper's data
/// </summary>
[JsonObject]
public class TrooperDTO
{
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
}
