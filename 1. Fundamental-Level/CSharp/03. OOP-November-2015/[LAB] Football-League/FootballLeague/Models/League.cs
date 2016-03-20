using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class League
{
    private static IList<Team> teams = new List<Team>();
    private static IList<Match> matches = new List<Match>();

    public static IEnumerable<Team> Teams
    {
        get { return teams; }
    }

    public static IEnumerable<Match> Mathes
    {
        get { return matches; }
    }

    public static void AddMatch(Match match)
    {
        if (!CheckIfMatchExists(match))
        {
            matches.Add(match);
        }
    }

    public static void AddTeam(Team team)
    {
        if (!CheckIfTeamExists(team))
        {
            teams.Add(team);
        }
    }

    public static bool CheckIfTeamExists(Team team)
    {
        return teams.Any(t => t.Name == team.Name);
    }

    public static bool CheckIfMatchExists(Match match)
    {
        return matches.Any(m => m.Id == match.Id);
    }
}