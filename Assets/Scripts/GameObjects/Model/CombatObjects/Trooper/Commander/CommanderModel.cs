using System.Collections.Generic;
/// <summary>
/// Trooper, who can issue Orders to Fireteams to his subordinates Fireteams
/// </summary>
public class CommanderModel : TrooperModel
{
    #region Fields
    private CommanderTier commanderTier;
    private List<FireteamModel> subordinates = new List<FireteamModel>();
    private List<BaseOrder> availableOrders = new List<BaseOrder>();
    #endregion

    #region Constructors
    public CommanderModel(Dictionary<string, object> parameters) : base(parameters)
    {
    }
    #endregion

    #region Properties
    /// <summary>
    /// Place of the Commander on the Platoon command line
    /// </summary>
    public CommanderTier CommanderTier
    {
        get => commanderTier;
    }
    /// <summary>
    /// Teams, that are under command of the Commander
    /// </summary>
    public List<FireteamModel> Subordinates
    {
        get => subordinates;
    }
    /// <summary>
    /// Collection of Orders, that the Commander can issue to his subordinates
    /// </summary>
    public List<BaseOrder> AvailableOrders
    {
        get => availableOrders;
    }
    #endregion
}
