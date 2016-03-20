using System;

class RockLq
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('.', n) + new string('*', n) + new string('.', n));

        int sideDotsCounter = n - 2;
        int middleDotsCounter = n + 2;
        for (int i = 0; i < n / 2; i++)
        {
            string sideDots = new string('.', sideDotsCounter);
            string middleDots = new string('.', middleDotsCounter);
            Console.WriteLine(sideDots + '*' + middleDots + '*' + sideDots);
            sideDotsCounter -= 2;
            middleDotsCounter += 4;
        }

        middleDotsCounter = n;
        sideDotsCounter = n - 2;
        int additionalDotsCounter = 1;
        for (int i = 0; i < n / 2; i++)
        {
            string sideDots = new string('.', sideDotsCounter);
            string middleDots = new string('.', middleDotsCounter);
            string additionalDots = new string('.', additionalDotsCounter);
            if (i == 0)
            {
                Console.WriteLine('*' + sideDots + '*' + middleDots + '*' + sideDots + '*');
                sideDotsCounter -= 2;
            }
            else
            {
                Console.WriteLine('*' + sideDots + '*' + additionalDots+ '*' + middleDots + '*'+ additionalDots + '*' + sideDots + '*');
                additionalDotsCounter += 2;
                sideDotsCounter -= 2;
            }
        }

        sideDotsCounter = n - 1;
        middleDotsCounter = n;
        for (int i = 0; i < n - 1; i++)
        {
            string sideDots = new string('.', sideDotsCounter);
            string middleDots = new string('.', middleDotsCounter);
            Console.WriteLine(sideDots + '*' + middleDots + '*' + sideDots);
            sideDotsCounter--;
            middleDotsCounter += 2;
        }
        
        Console.WriteLine(new string('*', n * 3));
    }
}