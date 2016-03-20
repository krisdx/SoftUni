using System;

class Joro //-k.d
{
    static void Main()
    {
        string leapYear = Console.ReadLine();
        float numberOfHolidays = float.Parse(Console.ReadLine());
        float hometownWeekedns = float.Parse(Console.ReadLine());

        float normalWeekends = 52 - hometownWeekedns;
        float holidayPlays = numberOfHolidays / 2;
        normalWeekends = (normalWeekends * 2) / 3;
        normalWeekends = normalWeekends + holidayPlays + hometownWeekedns;

        if (leapYear == "t")
        {
            normalWeekends += 3;
        }
        Console.WriteLine((int)normalWeekends);
    }
}
