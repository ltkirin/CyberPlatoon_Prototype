using System;
using System.Collections.Generic;
/// <summary>
/// Factory for crating Platoons
/// </summary>
public class PlatoonFactory
{
    private TrooperFactory trooperFactory;
    /// <summary>
    /// New Platoon model
    /// </summary>
    /// <param name="platoonData">DTO with base info</param>
    /// <returns>New Platoon</returns>
    public PlatoonModel CreatePlatoon(PlatoonDTO platoonData)
    {
        List<SquadModel> squads = new List<SquadModel>();
        foreach(SquadDTO squadData in platoonData.Squads)
        {
            SquadModel squad = CreateSquad(squadData);
            squads.Add(squad);
        }
        FireteamModel commandTeam = CreateFireteam(platoonData.CommandTeam);
        return new PlatoonModel(squads, commandTeam);
    }
    /// <summary>
    /// Create new Squad 
    /// </summary>
    /// <param name="squadData">Squad data</param>
    /// <returns>New squad</returns>
    private SquadModel CreateSquad(SquadDTO squadData)
    {
        List<FireteamModel> teams = new List<FireteamModel>();
        foreach (FireteamDTO teamData in squadData.Fireteams)
        {
            FireteamModel team = CreateFireteam(teamData);
            teams.Add(team);
        }
        return new SquadModel(teams);
    }
    /// <summary>
    /// Create new Fireteam 
    /// </summary>
    /// <param name="fireteamData">Fireteam data</param>
    /// <returns>New fireteam</returns>
    private FireteamModel CreateFireteam(FireteamDTO fireteamData)
    {
        throw new NotImplementedException();
    }

    
}
