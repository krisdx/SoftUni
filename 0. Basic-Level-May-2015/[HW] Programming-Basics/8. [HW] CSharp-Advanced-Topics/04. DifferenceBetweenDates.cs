using System;

class DifferenceBetweenDates
{
    static void Main()
    {
        Console.WriteLine("Please, enter first date [dd.MM.yyyy]:");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine();
        
        Console.WriteLine("Please, enter second date [dd.MM.yyyy]:");
        DateTime secondDate = DateTime.Parse(Console.ReadLine());
        

        TimeSpan daysBetween = firstDate - secondDate;
        if (firstDate > secondDate)
        {
            Console.WriteLine("\nThe days between the dates are: -{0:%d}\n", daysBetween);
        }
        else
        {
            Console.WriteLine("\n\nThe days between the dates are: {0:%d}\n\n", daysBetween);
        }
    }
}
