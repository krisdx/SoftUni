using System;

class SandGlass //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string asterisk = new string('*', n);
        Console.WriteLine(asterisk);

        int dotsCount = 1;
        int asteriskCount = n - 2;
        for (int i = 0; i <= (n - 2) / 2; i++)
        {
            string dots = new string('.', dotsCount);
            asterisk = new string('*', asteriskCount);

            if (i == 0)
            {
                Console.WriteLine(dots + asterisk + dots);
                asteriskCount -= 2;
                dotsCount++;
            }
            else
            {
                Console.WriteLine(dots + asterisk + dots);
                asteriskCount -= 2;
                dotsCount++;
            }
        }
        dotsCount = (n / 2) - 1;
        asteriskCount = 1;

        for (int i = 0; i < (n - 2) / 2; i++)
        {
            asteriskCount += 2;
            string dots = new string('.', dotsCount);
            asterisk = new string('*', asteriskCount);
            dotsCount--;
            Console.WriteLine(dots + asterisk + dots);

        }

        asterisk = new string('*', n);
        Console.Write(asterisk);
    }
}