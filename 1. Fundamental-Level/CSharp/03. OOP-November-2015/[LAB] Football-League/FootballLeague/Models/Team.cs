using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private const int MinimalYearFound = 1850;

    private string name;
    private string nickName;
    private DateTime dateFounded;
    private IList<Player> players;

    public Team(string name, string nickName, DateTime dateOfFounding)
    {
        this.Name = name;
        this.NickName = nickName;
        this.DateOfFounding = dateOfFounding;

        this.players = new List<Player>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value.Length < 5 || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The name lenght cannot be smaller than 5");
            }

            this.name = value;
        }
    }

    public string NickName
    {
        get
        {
            return this.nickName;
        }
        set
        {
            if (value.Length < 5 || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The name lenght cannot be smaller than 5");
            }

            this.nickName = value;
        }
    }

    public DateTime DateOfFounding
    {
        get
        {
            return this.dateFounded;
        }
        set
        {
            if (value.Year < MinimalYearFound)
            {
                throw new ArgumentOutOfRangeException("The year of founding must be after " + MinimalYearFound);
            }
        }
    }

    public IEnumerable<Player> Players
    {
        get
        {
            return this.players;
        }
    }

    public void AddPlayer(Player player)
    {
        if (CheckIfPlayerExists(player))
        {
            throw new InvalidOperationException("The player already exists.");
        }

        this.players.Add(player);

    }

    private bool CheckIfPlayerExists(Player player)
    {
        return this.players.Any(p => p.FirstName == player.FirstName &&
                                     p.LastName == player.LastName);
    }


}