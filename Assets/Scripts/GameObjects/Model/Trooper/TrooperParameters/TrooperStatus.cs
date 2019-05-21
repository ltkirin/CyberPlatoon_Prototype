/// <summary>
/// Storage for different Trooper status values
/// </summary>
public class TrooperStatus
{
    private bool isAlive = true;
    private bool isInvolvedInCombat = true;
    private bool isStunned = false;
    private bool isDazzled = false;

    /// <summary>
    /// Shows, if trooper is alive, 
    /// or dead and must be removed from fireteam
    /// </summary>
    public bool IsAlive
    {
        get => isAlive;
        set => isAlive = value;
    }
    /// <summary>
    /// Shows, if trooper does make his attacks in current combat turn
    /// </summary>
    public bool IsInvolvedInCombat
    {
        get => isInvolvedInCombat;
        set => isInvolvedInCombat = value;
    }
    /// <summary>
    /// Shows, if trooper is stunned and able to perform any actions
    /// </summary>
    public bool IsStunned
    {
        get => isStunned;
        set => isStunned = value;
    }
    /// <summary>
    /// Shows if trooper is dazzled and can't make his attacks, until effect is gone
    /// </summary>
    public bool IsDazzled
    {
        get => isDazzled;
        set => isDazzled = value;
    }
}
