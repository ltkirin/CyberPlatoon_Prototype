using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Model for Squad game object
/// </summary>
public class SquadModel : UnitModel
{
    /// <summary>
    /// Create new Squad model
    /// </summary>
    /// <param name="subordinateTeams">Fireteams, shic the Squad contins</param>
    public SquadModel(IList<FireteamModel> subordinateTeams) : base(subordinateTeams)
    {
    }
    /// <summary>
    /// Get the Trooper, who commands the Swuad
    /// </summary>
    /// <returns>Squad commander</returns>
    protected override CommanderModel GetUnitCommander()
    {
        return subordinateTeams
            .SelectMany(f => f.Troopers)
            .Where(t => t is CommanderModel)
            .FirstOrDefault() as CommanderModel;
    }


}
