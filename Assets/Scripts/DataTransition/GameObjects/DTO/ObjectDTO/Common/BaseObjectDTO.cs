using Newtonsoft.Json;

/// <summary>
/// Base class for DTO objects
/// </summary>
public abstract class BaseObjectDTO
{
    private long id;

    [JsonProperty]
    public long Id { get => id;
        set => id = value; }
}
