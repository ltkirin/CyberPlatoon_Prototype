using Newtonsoft.Json;
/// <summary>
/// Object tor transfer Fireteam data
/// </summary>
[JsonObject]
public class FireteamDTO
{
    private TrooperDTO[] troopers;
    /// <summary>
    /// Troopers, assigned to the Fireteam
    /// </summary>
    [JsonProperty]
    public TrooperDTO[] Troopers
    {
        get => troopers;
        set => troopers = value;
    }
}
