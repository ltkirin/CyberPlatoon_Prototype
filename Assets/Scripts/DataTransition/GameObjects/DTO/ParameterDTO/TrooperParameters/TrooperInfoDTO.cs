using Newtonsoft.Json;
/// <summary>
/// Data transfer object with Trooper's basic info
/// </summary>
[JsonObject]
public class TrooperInfoDTO
{
    private string name;
    private int tier;

    /// <summary>
    /// Trooper's name
    /// </summary>
    [JsonProperty]
    public string Name
    {
        get => name;
        set => value = name;
    }
    /// <summary>
    /// Trooper combat experience tier of the Trooper: 
    /// (0 = Rookie, 1 = Hardned, 2 = Veteran, 3 = Elite)
    /// </summary>
    [JsonProperty]
    public int Tier
    {
        get => tier;
        set => tier = value;
    }
}
