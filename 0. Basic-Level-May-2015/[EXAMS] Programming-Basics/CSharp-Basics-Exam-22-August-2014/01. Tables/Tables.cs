using System;

class Tables
{
    static void Main() //-k.d
    {
        long bundle1 = long.Parse(Console.ReadLine());
        long bundle2 = 2 * long.Parse(Console.ReadLine());
        long bundle3 = 3 * long.Parse(Console.ReadLine());
        long bundle4 = 4 * long.Parse(Console.ReadLine());
        long tableTops = long.Parse(Console.ReadLine());
        long tablesToBeMade = long.Parse(Console.ReadLine());

        long totalLegs = bundle1 + bundle2 + bundle3 + bundle4;
        long tablesMade = Math.Min(totalLegs / 4, tableTops);

        if (tablesMade > tablesToBeMade)
        {
            Console.WriteLine("more: {0}", tablesMade - tablesToBeMade);
            long tableTopsLeft = tablesMade - tablesToBeMade;
            long legsLeft = totalLegs - (tablesToBeMade * 4);
            Console.WriteLine("tops left: {0}, legs left: {1}", tableTopsLeft, legsLeft);
        }
        else if (tablesMade < tablesToBeMade)
        {
            Console.WriteLine("less: {0}", tablesMade - tablesToBeMade);
            long tableTopsNeeded = tablesToBeMade - tablesMade;
            long legsNeeded = tablesToBeMade * 4 - totalLegs;
            if (legsNeeded < 0)
            {
                legsNeeded = 0;
            }
            Console.WriteLine("tops needed: {0}, legs needed: {1}", tableTopsNeeded, legsNeeded);
        }
        else
        {
            Console.WriteLine("Just enough tables made: {0}", tablesMade);
        }
    }
}