using System;

class Sunlight // -k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int sideDotsCounter = 1;
        int middleDotsCounter = ((n * 3) - 5) / 2;
        int middleDotsCount = 0;
        for (int i = 0; i < (n * 3 - ((n * 3) / 2) - 1); i++)
        {
            string sideAsteriks = new string('*', 1);
            string sideDots = new string('.', sideDotsCounter);
            string middleDots = new string('.', middleDotsCounter);
            if (i == 0)
            {
                Console.WriteLine(new string('.', ((n * 3) / 2)) + '*' + new string('.', ((n * 3) / 2)));
            }
            else
            {
                if (i >= n)
                {
                    string middleAsteriks = new string('*', n * 3 - n * 2);
                    Console.WriteLine(sideDots + middleAsteriks + sideDots);
                    middleDotsCount++;
                }
                else
                {
                    Console.WriteLine(sideDots + sideAsteriks + middleDots + sideAsteriks + middleDots + sideAsteriks + sideDots);
                    middleDotsCounter--;
                    if (i > n - 1)
                    {

                    }
                    else
                    {
                        sideDotsCounter++;
                    }
                }
            }
        }

        Console.WriteLine(new string('*', n * 3));

        sideDotsCounter = (n * 3) - (n * 2);
        middleDotsCounter = n / 2;
        for (int i = 0; i < (n * 3 - ((n * 3) / 2) - 2); i++)
        {

            if (i < middleDotsCount)
            {
                string sideDots = new string('.', sideDotsCounter);
                string middleAsteriks = new string('*', n * 3 - n * 2);
                Console.WriteLine(sideDots + middleAsteriks + sideDots);
            }
            else
            {
                    sideDotsCounter--;
                    string sideAsteriks = new string('*', 1);
                    string sideDots = new string('.', sideDotsCounter);
                    string middleDots = new string('.', middleDotsCounter);
                    Console.WriteLine(sideDots + sideAsteriks + middleDots + sideAsteriks + middleDots + sideAsteriks + sideDots);
                    middleDotsCounter++;
            }
        }

        Console.WriteLine(new string('.', ((n * 3) / 2)) + '*' + new string('.', ((n * 3) / 2)));
    }
}