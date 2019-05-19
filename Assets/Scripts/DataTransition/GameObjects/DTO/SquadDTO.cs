using Newtonsoft.Json;
/// <summary>
/// Object to transfer Squad data
/// </summary>
[JsonObject]
public class SquadDTO
{
    private FireteamDTO[] fireteams;
    /// <summary>
    /// Data of Fireteams, included in the Squad
    /// </summary>
    [JsonProperty]
    public FireteamDTO[] Fireteams
    {
        get => fireteams;
        set => fireteams = value;
    }
}
