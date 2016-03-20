using System;

class Arrow //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());


        int dotsCount = n / 2;
        int numberSignCount = n;
        int sideDotsCount = 1;
        int middleDotsCount = n - 2;

        for (int i = 0; i < n - 1; i++) 
        {
            string dots = new string('.', dotsCount);
            string numberSign = new string('#', numberSignCount);
            string middleDots = new string('.', middleDotsCount);
            if (i == 0)
            {
                Console.WriteLine(dots + numberSign + dots);
                numberSignCount = n - (n - 1);
            }
            else
            {
                Console.WriteLine(dots + numberSign + middleDots + numberSign + dots);
            }
        }
        middleDotsCount = (middleDotsCount * 2) - 1;
        numberSignCount = (n / 2) + 1;
        dotsCount = n - 2;

        for (int i = 0; i < n; i++)
        {
            string dots = new string('.', dotsCount);
            string numberSign = new string('#', numberSignCount);
            string middleDots = new string('.', middleDotsCount);
            string sideDots = new string('.', sideDotsCount);

            if (i == 0)
            {
                Console.WriteLine(numberSign + dots + numberSign);
                numberSignCount = n - (n - 1);
            }

            else
            {
                Console.WriteLine(sideDots + numberSign + middleDots + numberSign + sideDots);
                sideDotsCount++;
                middleDotsCount -= 2;
            }
            if (middleDotsCount < 0)
            {
                Console.WriteLine(sideDots + '.' + numberSign + '.' + sideDots);
                break;
            }
        }
    }
}