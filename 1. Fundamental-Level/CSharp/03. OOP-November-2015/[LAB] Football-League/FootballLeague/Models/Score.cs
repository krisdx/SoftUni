using System;

public class Score
{
    private int homeTeamGoals;
    private int awayTeamGoals;

    public Score(int homeTeamGoals, int awayTeamGoals)
    {
        this.HomeTeamGoals = homeTeamGoals;
        this.AwayTeamGoals = awayTeamGoals;
    }

    public int HomeTeamGoals
    {
        get
        {
            return this.homeTeamGoals;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The home team goals count cannot be negative.");
            }

            this.homeTeamGoals = value;
        }
    }

    public int AwayTeamGoals
    {
        get
        {
            return this.awayTeamGoals;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The away team goals count cannot be negative.");
            }

            this.awayTeamGoals = value;
        }
    }
}