using System;

class PiggyBank
{
    static void Main()
    {
        double tankPrice = double.Parse(Console.ReadLine());
        int partyDays = int.Parse(Console.ReadLine());

        int normalDays = 30 - partyDays;
        int totalSavings = normalDays * 2;
        totalSavings -= (partyDays * 5);

        if (totalSavings <= 0)
        {
            Console.WriteLine("never");
        }
        else
        {
            double resultMonths = Math.Ceiling(tankPrice / totalSavings); //!Math.Ceilling
            int years = (int)resultMonths / 12;
            double months = Math.Ceiling(resultMonths % 12);

            Console.WriteLine("{0} years, {1} months", years, months);
        }   
    }
}