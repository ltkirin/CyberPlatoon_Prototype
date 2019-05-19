/// <summary>
/// An object, storing phesical parameters values of a Trooper
/// </summary>
public class TrooperStatistics
{
    private int endurance;
    private int morale;
    private int movementAllowance;
    private int accuracy;

    /// <summary>
    /// Create new Statistics objects with custom values 
    /// </summary>
    /// <param name="endurance"></param>
    /// <param name="morale"></param>
    /// <param name="movementAllowance"></param>
    /// <param name="accuracy"></param>
    public TrooperStatistics(int endurance = 10, int morale = 10, int movementAllowance = 10, int accuracy = 10)
    {
        this.endurance = endurance;
        this.morale = morale;
        this.movementAllowance = movementAllowance;
        this.accuracy = accuracy;
    }

    /// <summary>
    /// Value, represeenting Trooper's ability to stay alive after getting a wound
    /// </summary>
    public int Endurance
    {
        get => endurance;
        set => endurance = value;
    }
    /// <summary>
    /// Value, representing trooper's ability to operate normally under enemy fire and generally in a stress situation
    /// </summary>
    public int Morale
    {
        get => morale;
        set => morale = value;
    }
    /// <summary>
    /// Value, representing movement speed of a Trooper (in meters (units) per Turn)
    /// </summary>
    public int MovementAllowance
    {
        get => movementAllowance;
        set => movementAllowance = value;
    }
    /// <summary>
    /// Value, representing Trooper's skill to hit target by firearms
    /// </summary>
    public int Accuracy
    {
        get => accuracy;
        set => accuracy = value;
    }
}
