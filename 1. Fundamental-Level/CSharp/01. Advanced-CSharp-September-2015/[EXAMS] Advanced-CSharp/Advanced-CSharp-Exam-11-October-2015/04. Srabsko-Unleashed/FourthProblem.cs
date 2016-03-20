using System;
using System.Collections.Generic;
using System.Linq;

public class FourthProblem
{
    public static void Main()
    {
        Dictionary<string, Dictionary<string, ulong>> singersAndVenues = new Dictionary<string, Dictionary<string, ulong>>();

        string inputLine = Console.ReadLine();
        while (inputLine != "End")
        {
            string[] inputLineDetails;

            inputLineDetails = inputLine.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            if (inputLineDetails.Length <= 3)
            {
                inputLine = Console.ReadLine();
                continue;
            }

            string singer = string.Empty;
            string venue = string.Empty;
            bool isVenue = false;
            for (int i = 0; i < inputLineDetails.Length - 2; i++)
            {
                if (!isVenue)
                {
                    if (!inputLineDetails[i].Contains("@"))
                    {
                        singer += " " + inputLineDetails[i];
                    }
                    else
                    {
                        isVenue = true;
                        venue += " " + inputLineDetails[i];
                    }
                }
                else
                {
                    venue += " " + inputLineDetails[i];
                }
            }

            singer = singer.Trim();
            venue = venue.Trim().Remove(0, 1);

            ulong ticketPrice = ulong.Parse(inputLineDetails[inputLineDetails.Length - 2]);
            ulong ticketsCount = ulong.Parse(inputLineDetails[inputLineDetails.Length - 1]);

            if (singersAndVenues.ContainsKey(venue))
            {
                if (singersAndVenues[venue].ContainsKey(singer))
                {
                    singersAndVenues[venue][singer] += ticketPrice * ticketsCount;
                }
                else
                {
                    singersAndVenues[venue].Add(singer, ticketPrice * ticketsCount);
                }
            }
            else
            {
                Dictionary<string, ulong> currentSinger = new Dictionary<string, ulong>()
                {
                    {singer, ticketPrice * ticketsCount}
                };

                singersAndVenues.Add(venue, currentSinger);
            }

            inputLine = Console.ReadLine();
        }

        foreach (var venues in singersAndVenues)
        {
            Console.WriteLine("{0}", venues.Key);
            var sortedDictionaty = venues.Value.OrderByDescending(x => x.Value);
            foreach (var singer in sortedDictionaty)
            {
                Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
            }
        }
    }
}