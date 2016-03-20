using System;
using System.Collections.Generic;
using System.Linq;

class PopulationCounter
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, long>> populationCount = new Dictionary<string, Dictionary<string, long>>();

        string inputLine = Console.ReadLine();
        while (inputLine != "report")
        {
            string[] inputDetails = inputLine.Split('|');
            string city = inputDetails[0];
            string country = inputDetails[1];
            int population = int.Parse(inputDetails[2]);

            if (populationCount.ContainsKey(country))
            {
                if (populationCount[country].ContainsKey(city))
                {
                    populationCount[country][city] += population;
                }
                else
                {
                    populationCount[country].Add(city, population);
                }
            }
            else
            {
                Dictionary<string, long> cityAndPopulation = new Dictionary<string, long>{
                    {city, population}
                };
                populationCount.Add(country, cityAndPopulation);
            }

            inputLine = Console.ReadLine();
        }

        var sortedByPopulationCount = populationCount
            .OrderByDescending(x => x.Value.Values.Sum());

        Print(sortedByPopulationCount);
    }

    private static void Print(IOrderedEnumerable<KeyValuePair<string, Dictionary<string, long>>> sortedByPopulationCount)
    {
        foreach (var country in sortedByPopulationCount)
        {
            Console.WriteLine("{0} (total population: {1})", country.Key, country.Value.Values.Sum());

            var sortedByCitiesCount = country.Value.OrderByDescending(x => x.Value);
            foreach (var city in sortedByCitiesCount)
            {
                Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
            }
        }
    }
}