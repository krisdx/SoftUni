using System;

public class MagicDates //-k.d
{
    public static void Main()
    {
        int startYear = int.Parse(Console.ReadLine());
        int endYear = int.Parse(Console.ReadLine());
        int magicWeight = int.Parse(Console.ReadLine());

        DateTime startDate = new DateTime(startYear, 1, 1);
        DateTime endDate = new DateTime(endYear, 12, 31);

        bool solutionFound = false;
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            int currentWeigth = GetWeigth(date);
            if (currentWeigth == magicWeight)
            {
                Console.WriteLine("{0:d2}-{1:d2}-{2}", date.Day, date.Month, date.Year);
                solutionFound = true;
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }

    private static int GetWeigth(DateTime date)
    {
        int d1 = date.Day / 10;
        int d2 = date.Day % 10;
        int d3 = date.Month / 10;
        int d4 = date.Month % 10;
        int d5 = (date.Year / 1000) % 10;
        int d6 = (date.Year / 100) % 10;
        int d7 = (date.Year / 10) % 10;
        int d8 = (date.Year / 1) % 10;
        int[] digits = { d1, d2, d3, d4, d5, d6, d7, d8};

        int currentWeigth = 0;
        for (int first = 0; first < digits.Length; first++)
        {
            for (int second = first + 1; second < digits.Length; second++)
            {
                currentWeigth += digits[first] * digits[second];
            }
        }
        return currentWeigth;
    }
}