using System;

class Star
{
    static void Main() //-k.d
    {
        byte n = byte.Parse(Console.ReadLine());

        int middleCounter = 1;
        int sideCounter = n;
        for (int i = 0; i < n / 2; i++)
        {
            if (i == 0)
            {
                Console.Write(new string('.', sideCounter));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', sideCounter));
                sideCounter--;
            }
            else
            {
                Console.Write(new string('.', sideCounter));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', middleCounter));
                middleCounter += 2;
                Console.Write(new string('*', 1));
                Console.Write(new string('.', sideCounter));
                sideCounter--;
            }
            Console.WriteLine();
        }

        Console.WriteLine(new string('*', ((2 * n + 1) - middleCounter) / 2) + new string('.', middleCounter) + new string('*', ((2 * n + 1) - middleCounter) / 2));

        sideCounter = 1;
        middleCounter = (2 * n + 1) - 4;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write(new string('.', sideCounter));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', middleCounter));
            middleCounter -= 2;
            Console.Write(new string('*', 1));
            Console.Write(new string('.', sideCounter));
            sideCounter++;

            Console.WriteLine();
        }

        Console.WriteLine(new string('.', sideCounter) + new string('*', 1) + new string('.', middleCounter / 2) + new string('*', 1) + new string('.', middleCounter / 2) + new string('*', 1) + new string('.', sideCounter));

        sideCounter--;
        int middleDots = sideCounter;
        int middleDot = 1;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write(new string('.', sideCounter));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', middleDots));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', middleDot));
            middleDot += 2;
            Console.Write(new string('*', 1));
            Console.Write(new string('.', middleDots));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', sideCounter));
            sideCounter--;
            Console.WriteLine();
        }
        Console.WriteLine(new string('*', ((2 * n + 1) - middleCounter) / 2) + new string('.', middleCounter) + new string('*', ((2 * n + 1) - middleCounter) / 2));
    }
}