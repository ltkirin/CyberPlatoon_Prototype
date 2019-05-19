using Newtonsoft.Json;
[JsonObject]
public class PlatoonDTO
{
    private FireteamDTO commandTeam;
    private SquadDTO[] squads;
    /// <summary>
    /// Informatioan of Fireteam, including the Platoon commander
    /// </summary>
    [JsonProperty]
    public FireteamDTO CommandTeam
    {
        get => commandTeam;
        set => commandTeam = value;
    }
    /// <summary>
    /// Information of Squads, included in the Platton
    /// </summary>
    [JsonProperty]
    public SquadDTO[] Squads
    {
        get => squads;
        set => squads = value;
    }
}
