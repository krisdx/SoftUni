using System;

class CountBeers
{
    static void Main()
    {
        string beerAmount = Console.ReadLine();
        int totalBeers = 0;
        while (beerAmount != "End")
        {
            string[] beerDetails = beerAmount.Split();
            int count = int.Parse(beerDetails[0]);
            string measure = beerDetails[1];

            if (measure == "stacks")
            {
                count *= 20;
            }

            totalBeers += count;

            beerAmount = Console.ReadLine();
        }

        Console.WriteLine("{0} stacks + {1} beers", totalBeers / 20, totalBeers % 20);
    }
}