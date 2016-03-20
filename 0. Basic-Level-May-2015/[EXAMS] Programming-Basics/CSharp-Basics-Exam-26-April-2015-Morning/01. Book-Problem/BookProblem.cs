using System;

class BookProblem
{
    static void Main()
    {
        int bookPages = int.Parse(Console.ReadLine());
        int CampingDays = int.Parse(Console.ReadLine());
        int pagesReadADay = int.Parse(Console.ReadLine());
       
        if (CampingDays == 30 || pagesReadADay == 0)
        {
            Console.WriteLine("never");
        }
        else
        {
            decimal normalDays = 30 - CampingDays;
            decimal pagesRead = pagesReadADay * normalDays;
            decimal monthsNeeded = (int)Math.Ceiling(bookPages / pagesRead);
            int yearsToRead = (int)monthsNeeded / 12;
            int monthsToRead = (int)monthsNeeded % 12;

            Console.WriteLine("{0} years {1} months", yearsToRead, monthsToRead);
        }    
    }
}