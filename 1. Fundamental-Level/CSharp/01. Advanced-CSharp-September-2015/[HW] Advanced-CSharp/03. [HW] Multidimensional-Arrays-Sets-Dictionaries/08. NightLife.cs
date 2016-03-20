using System;
using System.Collections.Generic;

// Being a nerd means writing programs about night clubs instead of actually going to ones. Spiro is a nerd and he decided to summarize some info about the most popular night clubs around the world. 

// He's come up with the following structure – he'll summarize the data by city, where each city will have a list of venues and each venue will have a list of performers. Help him finish the program, so he can stop staring at the computer screen and go get himself a cold beer.

// You'll receive the input from the console. There will be an arbitrary number of lines until you receive the string "END". Each line will contain data in format: "city;venue;performer". If either city, venue or performer don't exist yet in the database, add them. If either the city and/or venue already exist, update their info.

// Cities should remain in the order in which they were added, venues should be sorted alphabetically and performers should be unique (per venue) and also sorted alphabetically.

// Print the data by listing the cities and for each city its venues (on a new line starting with "->") and performers (separated by comma and space). Check the examples to get the idea. And grab a beer when you're done, you deserve it. Spiro is buying

class NightLife
{
    static void Main()
    {
        Dictionary<string, SortedDictionary<string, string>> clubs = new Dictionary<string, SortedDictionary<string, string>>();

        string performance = Console.ReadLine().Trim();
        while (performance != "END")
        {
            string[] performanceDetalis = performance.Split(';');
            string city = performanceDetalis[0];
            string club = performanceDetalis[1];
            string performer = performanceDetalis[2];

            if (clubs.ContainsKey(city))
            {
                if (clubs[city].ContainsKey(club))
                {
                    clubs[city][club] = performer;
                }
                else
                {
                    clubs[city].Add(club, performer);
                }
            }
            else
            {
                SortedDictionary<string, string> clubAndPerformer = new SortedDictionary<string, string>
                {
                    {club, performer}
                };

                clubs.Add(city, clubAndPerformer);
            }

            performance = Console.ReadLine().Trim();
        }

        PrintPerformances(clubs);
    }

    private static void PrintPerformances(Dictionary<string, SortedDictionary<string, string>> clubs)
    {
        foreach (var performance in clubs)
        {
            Console.Write("{0}\n->", performance.Key);
            Console.WriteLine(string.Join("; ", performance.Value));
        }
    }
}