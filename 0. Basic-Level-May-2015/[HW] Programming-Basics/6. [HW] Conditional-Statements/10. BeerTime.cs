using System;
using System.Globalization;

// A beer time is after 1:00 PM and before 3:00 AM. Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator) and prints “beer time” or “non-beer time” according to the definition above or “invalid time” if the time cannot be parsed. Note that you may need to learn how to parse dates and times. 

class BeerTime
{
    static void Main()
    {   
        Console.Write("Enter time (hh:mm tt - for example 09:13 AM): ");
        string input = Console.ReadLine();
        
        DateTime timeNow = DateTime.Now;
        try
        {
            DateTime.TryParseExact(input, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeNow);
        }
        catch (Exception)
        {
            Console.WriteLine("\ninvalid time\n");
        }

        string startBeer = "01:00 PM";
        DateTime startBeerTime = DateTime.Now;
        DateTime.TryParseExact(startBeer, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out startBeerTime);

        string endBeer = "03:00 AM";
        DateTime endBeerTime = DateTime.Now;
        DateTime.TryParseExact(endBeer, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out endBeerTime);

        if ((timeNow < endBeerTime) || (timeNow > startBeerTime))
        {
            Console.WriteLine("\nBeer time.\n");
        }
        else
        {
            Console.WriteLine("\nNon-beer time\n");
        }
    }
}

