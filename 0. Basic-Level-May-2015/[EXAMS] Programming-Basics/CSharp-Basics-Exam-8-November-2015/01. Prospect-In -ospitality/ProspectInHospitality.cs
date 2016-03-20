using System;

public class ProspectInHospitality
{
    public static void Main()
    {
        uint buildersNeeded = uint.Parse(Console.ReadLine());
        uint receptionistsNeeded = uint.Parse(Console.ReadLine());
        uint chambermaidsNeeded = uint.Parse(Console.ReadLine());
        uint technicansNeeded = uint.Parse(Console.ReadLine());
        uint otherStaffNeeded = uint.Parse(Console.ReadLine());
        decimal nikiSalary = decimal.Parse(Console.ReadLine());
        decimal USACurrency = decimal.Parse(Console.ReadLine());
        decimal mySalary = decimal.Parse(Console.ReadLine());
        decimal budget = decimal.Parse(Console.ReadLine());

        decimal totalExpences =
            (buildersNeeded * 1500.04m) +
            (receptionistsNeeded * 2102.10m) +
            (chambermaidsNeeded * 1465.46m) +
            (technicansNeeded * 2053.33m) +
            (otherStaffNeeded * 3010.98m) +
            (nikiSalary * USACurrency) +
            mySalary;

        Console.WriteLine("The amount is: {0:f2} lv.", totalExpences);
        if (totalExpences <= budget)
        {
            Console.WriteLine(@"YES \ Left: {0:f2} lv.", budget - totalExpences);
        }
        else
        {
            Console.WriteLine(@"NO \ Need more: {0:f2} lv.", Math.Abs(budget - totalExpences));
        }
    }
}