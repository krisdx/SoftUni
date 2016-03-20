using System;

class CountBeers //-k.d
{
    static void Main()
    {
        int beersCounter = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            string[] beerDetails = input.Split(' ');
            int count = int.Parse(beerDetails[0]);
            string measure = beerDetails[1];

            if (measure == "stacks")
            {
                beersCounter += count * 20;
            }
            else
            {
                beersCounter += count;
            }
        }

        int totalStacks = beersCounter / 20;
        int totalBeers = beersCounter % 20;
        Console.WriteLine("{0} stacks + {1} beers", totalStacks, totalBeers);
    }
}