using System;

class TravellerBob
{
    static void Main()//-k.d
    {
        string leapYear = Console.ReadLine();
        int contractMonths = int.Parse(Console.ReadLine());
        int familyMonths = int.Parse(Console.ReadLine());

        double normalMonths = 12 - (contractMonths + familyMonths);
        double totalTravels = contractMonths * (3 * 4);
        totalTravels += familyMonths * (2 * 2);
        totalTravels += (normalMonths * (3 * 4)) * 3 / 5;

        if (leapYear == "leap")
        {
            double percent = totalTravels * 0.05;
            totalTravels += percent;
        }
        Console.WriteLine((int)totalTravels);
    }
}