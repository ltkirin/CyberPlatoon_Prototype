using Newtonsoft.Json;

/// <summary>
/// Object to transfer Weapon data to create a Weapon model
/// </summary>
[JsonObject]
public class WeaponDTO
{
    /// <summary>
    /// Weapon name
    /// </summary>
    [JsonProperty]
    public string Name { get; set; }
    /// <summary>
    /// Weapon type (converts into WeaponType Enum)
    /// </summary>
    [JsonProperty]
    public int Type { get; set; }
    /// <summary>
    /// Attack type (converts into RollType enum)
    /// </summary>
    [JsonProperty]
    public int AttackType { get; set; }
    /// <summary>
    /// Count of Attacks, ерфе weapon can make per turn
    /// </summary>
    [JsonProperty]
    public int RateOfFire { get; set; }
    /// <summary>
    /// Accuracy modifier of the weapon
    /// </summary>
    [JsonProperty]
    public int AttackModifier { get; set; }
    /// <summary>
    /// Ability to pierce Cover and Vehicel armor of the Weapon
    /// </summary>
    [JsonProperty]
    public int ArmorPiercing { get; set; }
    /// <summary>
    /// List of Ranges (convert into FirefightRange enum), where this Weapon rerolls attacks
    /// </summary>
    [JsonProperty]
    public int[] RerollRanges { get; set; }
    /// <summary>
    /// List of Ranges (convert into FirefightRange enum), on which the weapon can operate 
    /// (Generally it covers all ranges, but handguns, grenades and some ordonance 
    /// weapons have some restrictions)
    /// </summary>
    [JsonProperty]
    public int[] UsedRanges { get; set; }
}
