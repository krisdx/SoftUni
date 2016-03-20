using System;

class SummerTime
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}{1}{0}", new string(' ', n / 2), new string('*', n + 1));

        for (int i = 0; i < n / 2 + 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string(' ', n / 2), new string(' ', n - 1));
        }

        int sideSpacesCount = n / 2 - 1;
        int middleSpacesCount = n * 2 - ((sideSpacesCount * 2) + 2);
        for (int i = 0; i < n / 2 - 1; i++)
        {
            string sideSpaces = new string(' ', sideSpacesCount);
            string middleSpaces = new string(' ', middleSpacesCount);
            Console.WriteLine("{0}*{1}*{0}", sideSpaces, middleSpaces);
            sideSpacesCount--;
            middleSpacesCount += 2;
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("*{0}*", new string('.', n * 2 - 2));
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("*{0}*", new string('@', n * 2 - 2));
        }

        Console.WriteLine(new string('*', n * 2));
    }
}