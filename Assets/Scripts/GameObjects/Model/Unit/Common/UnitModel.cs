using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Base model for Units models
/// </summary>
public abstract class UnitModel
{
    #region Fields
    protected CommanderModel unitCommander;
    protected List<FireteamModel> subordinateTeams;
    #endregion

    public UnitModel()
    { }
    /// <summary>
    /// Create Unit and fill it with previously composed Fireteams
    /// </summary>
    /// <param name="subordinateTeams">Teams to fill the Unit</param>
    public UnitModel(IList<FireteamModel> subordinateTeams)
    {
        this.subordinateTeams = subordinateTeams.ToList();
        unitCommander = GetUnitCommander();
    }

    #region Properties
    /// <summary>
    /// Trooper, which is in command in current Unit
    /// </summary>
    public CommanderModel UnitCommander
    {
        get => unitCommander;
    }
    /// <summary>
    /// Fireteams, that comprise the Unit
    /// </summary>
    public List<FireteamModel> SubordinateTeams
    {
        get => subordinateTeams;
    }
    #endregion

    /// <summary>
    /// Set cpmmander of the Unit
    /// </summary>
    protected abstract CommanderModel GetUnitCommander();

}
