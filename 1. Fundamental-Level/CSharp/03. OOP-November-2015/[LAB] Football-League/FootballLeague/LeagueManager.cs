using System;

public static class LeagueManager
{
    public static void HandleInput(string input)
    {
        var inputArgs = input.Split();
        switch (inputArgs[0])
        {
            case "AddTeam":
                AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]));
                break;
        }
    }

    private static void AddTeam(string name, string nickName, DateTime dateOfFounding)
    {
        Team team = new Team(name, nickName, dateOfFounding);
        if (!League.CheckIfTeamExists(team))
        {
            League.AddTeam(team);
        }
    }
}