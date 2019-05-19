/// <summary>
/// Type of order, defining suitable situations for usage 
/// and defining, what orders a Fireteam can executa in current 
/// Morale state.
/// </summary>
public enum OrderType
{
    /// <summary>
    /// Orders, providing retreating and braking distance with enemy
    /// </summary>
    Disengaing = 0,
    /// <summary>
    /// Orders, increasing efficincy of using covers and firing out of them 
    /// </summary>
    Defensive = 1,
    /// <summary>
    /// Orders, allowing to take advantageous positions during combat
    /// </summary>
    Tactical = 2,
    /// <summary>
    /// Orders, allwoing to reduce dustance to the enemy and
    /// deal more damage, or suffer less casualties in close combat
    /// </summary>
    Offensive = 3

}
