using Newtonsoft.Json;
/// <summary>
/// Object to transfer Trooper's physical statistics data
/// </summary>
[JsonObject]
public class TrooperStaticticsDTO
{
    private int endurance;
    private int morale;
    private int movementAllowance;
    private int accuracy;

    /// <summary>
    /// Posibility of the trooper to survive being wounded
    /// </summary>
    [JsonProperty]
    public int Endurance { get => endurance; set => endurance = value; }
    /// <summary>
    /// The Trooper's ability to stay focused under fire and combat pressure
    /// </summary>
    [JsonProperty]
    public int Morale { get => morale; set => morale = value; }
    /// <summary>
    /// Number of meters, Trooper can move per turn
    /// </summary>
    [JsonProperty]
    public int MovementAllowance { get => movementAllowance; set => movementAllowance = value; }
    /// <summary>
    /// Trooper's ToHit bonus, that affect his shooting Attacks
    /// </summary>
    [JsonProperty]
    public int Accuracy { get => accuracy; set => accuracy = value; }
}
