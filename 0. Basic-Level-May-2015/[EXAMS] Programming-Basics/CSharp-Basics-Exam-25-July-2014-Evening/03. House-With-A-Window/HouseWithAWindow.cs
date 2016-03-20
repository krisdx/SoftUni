using System;

class HouseWithAWindow //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int sideCount = ((n * 2) - 1) / 2;
        int middleCount = 0;

        for (int i = 0; i < n; i++)
        {
            Console.Write(new string('.', sideCount));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', middleCount));
            if (i == 0)
            {
                middleCount++;
            }
            else middleCount += 2;

            if (i >= 1)
            {
                Console.Write(new string('*', 1));
            }
            Console.Write(new string('.', sideCount));
            sideCount--;
            Console.WriteLine();
        }

        Console.WriteLine(new string('*', n * 2 - 1));

        middleCount = (n * 2 - 1) - 2;
        for (int i = 0; i < n; i++)
        {

            if (i >= (n - (n / 2)) / 2 && i < (n - (n / 2)) / 2 + (n / 2))
            {
                Console.Write(new string('*', 1));
                Console.Write(new string('.', n / 2));
                Console.Write(new string('*', n - 3));
                Console.Write(new string('.', n / 2));
                Console.Write(new string('*', 1));
            }
            else
            {
                Console.Write(new string('*', 1));
                Console.Write(new string('.', middleCount));
                Console.Write(new string('*', 1));
            }
            Console.WriteLine();
        }
        Console.WriteLine(new string('*', n * 2 - 1));
    }
}