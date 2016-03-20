using System;

public class Match
{
    private string id;

    public Match(Team homeTeam, Team awayTeam, Score score, string id)
    {
        this.HomeTeam = homeTeam;
        this.AwayTeam = awayTeam;
        this.Score = score;
        this.Id = id;
    }

    public Team GetWinner()
    {
        if (this.IsDraw())
        {
            return null;
        }

        return this.Score.HomeTeamGoals > this.Score.AwayTeamGoals ? this.HomeTeam : this.AwayTeam;
    }

    private bool IsDraw()
    {
        return this.Score.AwayTeamGoals == this.Score.HomeTeamGoals;
    }

    public Team HomeTeam { get; set; }

    public Team AwayTeam { get; set; }

    public Score Score { get; set; }

    public string Id
    {
        get
        {
            return this.id;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Thi ID cannot be empty.");
            }

            this.id = value;
        }
    }
}
