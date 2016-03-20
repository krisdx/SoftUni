using System;

class House //k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int sideDotsCount = n / 2;
        int middleDotsCount = 1;
        int asteriksCount = 1;

        for (int i = 0; i < n / 2; i++)
        {
            string sidedots = new string('.', sideDotsCount);
            string asteriks = new string('*', asteriksCount);
            string middleDots = new string('.', middleDotsCount);
            if (i == 0)
            {
                Console.WriteLine(sidedots + asteriks + sidedots);
                sideDotsCount--;
            }
            else
            {
                Console.WriteLine(sidedots + asteriks + middleDots + asteriks + sidedots);
                sideDotsCount--;
                middleDotsCount += 2;
            }
        }

        asteriksCount = n;
        sideDotsCount = n / 4;
        middleDotsCount = n - (sideDotsCount * 2) - 2;
        for (int i = 0; i <= n / 2; i++)
        {
            string sideDots = new string('.', sideDotsCount);
            string asteriks = new string('*', asteriksCount);
            string middleDots = new string('.', middleDotsCount);

            if (i == 0)
            {
                Console.WriteLine(asteriks);
                asteriksCount = n - (n - 1);
            }
            else if (i <= n / 2 - 1)
            {
                Console.WriteLine(sideDots + asteriks + middleDots + asteriks + sideDots);   
            }
            else
            {
                asteriks = new string('*', n - (sideDotsCount * 2));
                Console.WriteLine(sideDots + asteriks + sideDots);
            }
            if (i >= n / 2)
            {
                asteriksCount += n - (sideDotsCount * 2) - 1;
            }
        }
    }
}