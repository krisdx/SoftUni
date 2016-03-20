using System;

class Electricity //-k.d
{
    static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        string t = Console.ReadLine();

        string[] times = t.Split(':');
        int hours = int.Parse(times[0]);
        int minutes = int.Parse(times[1]);

        double oneFlatConsumption = 0;
        double result = 0;
        if ((hours >= 14 && minutes >= 0) && (hours <= 18 && minutes <= 59))
        {
            oneFlatConsumption = (2 * 100.53) + (2 * 125.9);
            result = oneFlatConsumption * flats * floors;
            Console.WriteLine(Math.Floor(result) + " Watts");
        }
        else if ((hours >= 19 && minutes >= 0) && (hours <= 23 && minutes <= 59))
        {
            oneFlatConsumption = (7 * 100.53) + (6 * 125.9);
            result = oneFlatConsumption * flats * floors;
            Console.WriteLine(Math.Floor(result) + " Watts");
        }
        else if ((hours >= 0 && minutes >= 0) && (hours <= 8 && minutes <= 59))
        {
            oneFlatConsumption = (1 * 100.53) + (8 * 125.9);
            result = oneFlatConsumption * flats * floors;
            Console.WriteLine(Math.Floor(result) + " Watts");
        }
        else
        {
            Console.WriteLine("0 Watts");
        }
    }
}