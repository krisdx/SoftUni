using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class OlympicsAreComing
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> olympicsLog = new Dictionary<string, Dictionary<string, int>>();

        string inputLine = Console.ReadLine().Trim();
        while (inputLine != "report")
        {
            string[] inputDetails = inputLine.Split('|');
            string athlete = Regex.Replace(inputDetails[0].Trim(), @"\s+", " ").Trim();
            string country = Regex.Replace(inputDetails[1].Trim(), @"\s+", " ").Trim();

            if (olympicsLog.ContainsKey(country))
            {
                if (!olympicsLog[country].ContainsKey(athlete))
                {
                    olympicsLog[country].Add(athlete, 0);
                }

                olympicsLog[country][athlete]++;
            }
            else
            {
                Dictionary<string, int> athleteWin = new Dictionary<string, int>
                {
                    {athlete, 1}
                };

                olympicsLog.Add(country, athleteWin);
            }

            inputLine = Console.ReadLine().Trim();
        }

        var sortedOlympicLog =
            olympicsLog.OrderByDescending(x => x.Value.Values.Sum());
        foreach (var country in sortedOlympicLog)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins", country.Key, country.Value.Count, country.Value.Values.Sum());
        }
    }
}