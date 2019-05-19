using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Model of the Platoon Game object
/// </summary>
public class PlatoonModel : UnitModel
{
    private List<SquadModel> subordinateSquads;

    /// <summary>
    /// Create new Platoon 
    /// </summary>
    /// <param name="subordinateSquads">Squads, which are contained in the Platoon</param>
    /// <param name="commandTeam">Team of the Platoon Commander</param>
    public PlatoonModel(IList<SquadModel> subordinateSquads, FireteamModel commandTeam) 
    {
        this.subordinateSquads = subordinateSquads.ToList();
        subordinateTeams = subordinateSquads.SelectMany(s => s.SubordinateTeams).ToList();
        subordinateTeams.Add(commandTeam);
        GetUnitCommander();
    }

    /// <summary>
    /// Get the trooper, who comands the Platoon
    /// </summary>
    /// <returns>Platoon commander</returns>
    protected override CommanderModel GetUnitCommander()
    {
        return subordinateTeams
            .SelectMany(f => f.Troopers)
            .Where(t => t is CommanderModel
            && (t as CommanderModel).CommanderTier == CommanderTier.PlatoonLeader)
            .FirstOrDefault() as CommanderModel;
    }
}
