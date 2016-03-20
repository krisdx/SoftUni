using System;
using System.Collections.Generic;
using System.Text;

class TheFootballStatistician
{
    static void Main()
    {
        SortedDictionary<string, int> league = new SortedDictionary<string, int>();
        league.Add("Arsenal", 0);
        league.Add("Chelsea", 0);
        league.Add("ManchesterCity", 0);
        league.Add("ManchesterUnited", 0);
        league.Add("Liverpool", 0);
        league.Add("Everton", 0);
        league.Add("Southampton", 0);
        league.Add("Tottenham", 0);


        decimal money = decimal.Parse(Console.ReadLine());

        int matchesCount = 0;
        string matchResults = Console.ReadLine().Trim();
        while (matchResults != "End of the league.")
        {
            string[] matchDetails = matchResults.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string team1 = matchDetails[0];
            char result = char.Parse(matchDetails[1]);
            string team2 = matchDetails[2];

            switch (result)
            {
                case '1': league[team1] += 3; break;
                case 'X': league[team1]++; league[team2]++; break;
                case '2': league[team2] += 3; break;
            }
            matchesCount++;

            matchResults = Console.ReadLine().Trim();
        }

        Console.WriteLine("{0:f2}lv.", (money * matchesCount) * 1.94m);

        foreach (var team in league)
        {
            if (team.Key == "ManchesterCity")
            {
                Console.WriteLine("Manchester City - {0} points.", team.Value);
            }
            else if (team.Key == "ManchesterUnited")
            {
                Console.WriteLine("Manchester United - {0} points.", team.Value);
            }
            else
            {
                Console.WriteLine("{0} - {1} points.", team.Key, team.Value);
            }
        }
    }
}