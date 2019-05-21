/// <summary>
/// Base class for all objects, loaded with multiple parameters
/// </summary>
public abstract class ModelBase
{
    protected long id;

    protected bool isActive;
    /// <summary>
    /// Create new Model Base
    /// </summary>
    /// <param name="dto">Object DTO with parameters for Model</param>
    public ModelBase(BaseObjectDTO dto)
    {
        id = dto.Id;
    }
    /// <summary>
    /// Runtime ID of the object 
    /// </summary>
    public long Id
    {
        get => id;
    }
    /// <summary>
    /// Is model involved in current runtime
    /// </summary>
    public bool IsActive
    {
        get => isActive;
    }
    /// <summary>
    /// Activate model of the object
    /// </summary>
    public virtual void Activate()
    {
        isActive = true; 
    }
    /// <summary>
    /// Disactivate the object
    /// </summary>
    public virtual void Disactivate()
    {
        isActive = false;
    }
}
