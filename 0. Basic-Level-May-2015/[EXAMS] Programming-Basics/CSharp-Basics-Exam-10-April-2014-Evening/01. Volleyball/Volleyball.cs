using System;

class Volleyball //-k.d
{
    static void Main()
    {
        string leapYear = Console.ReadLine();
        double numberOfHolidays = double.Parse(Console.ReadLine());
        double homeTownWeekends = double.Parse(Console.ReadLine());

        double totalPlays = 0;

        totalPlays = 48 - homeTownWeekends;
        totalPlays = totalPlays * 3 / 4;
        numberOfHolidays = numberOfHolidays * 2 / 3;
        totalPlays += numberOfHolidays;
        totalPlays += homeTownWeekends;

        if (leapYear == "leap")
        {
            totalPlays += 0.15f * totalPlays;
            Console.WriteLine((int)totalPlays);
        }
        else
        {
            Console.WriteLine((int)totalPlays);
        }
    }
}