using System;

class WorkHours //-k.d
{
    static void Main()
    {
        decimal hours = decimal.Parse(Console.ReadLine());
        decimal availableDays = decimal.Parse(Console.ReadLine());
        decimal productivity = decimal.Parse(Console.ReadLine());

        availableDays = availableDays - (availableDays * (decimal)0.1);
        decimal ToFinish = availableDays * 12;
        ToFinish = ToFinish * (productivity / 100);
        int result = (int)hours - (int)ToFinish;

        if (0 >= result)
        {
            Console.WriteLine("Yes");
            Console.WriteLine((int)-result);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine((int)-result);
        }
    }
}
