using System;

class Car
{
    static void Main()//-k.d
    {
        int n = int.Parse(Console.ReadLine());

        int sideCounter = (n * 3) - (n * 2);
        int middleCounter = (n * 3) - (n * 2);
       
        for (int i = 0; i < n / 2; i++)
        {
            if (i == 0)
            {
                Console.Write(new string('.', sideCounter));
                Console.Write(new string('*', middleCounter));
                Console.Write(new string('.', sideCounter));
                sideCounter--;
            }
            else
            {
                Console.Write(new string('.', sideCounter));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', middleCounter));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', sideCounter));
                sideCounter--;
                middleCounter += 2;
            }
            Console.WriteLine();
        }

        sideCounter += 1;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            if (i == 0)
            {
                Console.Write(new string('*', sideCounter));
                Console.Write(new string('.', middleCounter));
                Console.Write(new string('*', sideCounter));
                middleCounter = (n * 3) - 2;
            }
            else
            {
                Console.Write(new string('*', 1));
                Console.Write(new string('.', middleCounter));
                Console.Write(new string('*', 1));
            }
            Console.WriteLine();
        }

        Console.WriteLine(new string('*', n * 3));

        sideCounter = n / 2;
        middleCounter = n - 2;
        for (int i = 0; i <= n / 2 - 1; i++)
        {
            if (i == n / 2 - 2)
            {
                Console.Write(new string('.', sideCounter));
                Console.Write(new string('*', sideCounter + 1));
                Console.Write(new string('.', middleCounter));
                Console.Write(new string('*', sideCounter + 1));
                Console.WriteLine(new string('.', sideCounter));
                break;
            }
            else
            {
                Console.Write(new string('.', sideCounter));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', sideCounter - 1));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', middleCounter));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', sideCounter - 1));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', sideCounter));
            }
            Console.WriteLine();
        }
    }
}