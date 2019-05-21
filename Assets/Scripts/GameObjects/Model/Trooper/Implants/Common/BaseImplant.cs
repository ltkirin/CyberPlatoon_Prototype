/// <summary>
/// Base class for all Implants objects, used to upgrade trooper;
/// </summary>
public abstract class BaseImplant
{
    protected int tier;

    /// <summary>
    /// Create new Implant instance
    /// </summary>
    /// <param name="type">Implant type</param>
    /// <param name="tier">Implant tier</param>
    public BaseImplant(int tier = 1)
    {
        this.tier = tier;
    }

    /// <summary>
    /// Value, representing degree of advancement of current implant.
    /// Eficciency of the implant allways deppends on it's Tier
    /// </summary>
    public int Tier
    {
        get => tier;
    }
}
