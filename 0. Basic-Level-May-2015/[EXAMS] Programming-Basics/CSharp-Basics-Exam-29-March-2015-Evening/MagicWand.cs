using System;

class MagicWand
{
    static void Main() //-k.d
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('.', (((n * 3) + 2) - 1) / 2) + '*' + new string('.', (((n * 3) + 2) - 1) / 2));

        int sideDotsCounter = ((n * 3 + 2) - 3) / 2;
        int middleDotsCounter = 1;
        for (int i = 0; i < n / 2 + 1; i++)
        {
            string sideDots = new string('.', sideDotsCounter);
            string middleDots = new string('.', middleDotsCounter);
            Console.WriteLine("{0}*{1}*{0}", sideDots, middleDots);
            sideDotsCounter--;
            middleDotsCounter += 2;
        }

        Console.WriteLine(new string('*', n) + new string('.', n + 2) + new string('*', n));

        sideDotsCounter = 1;
        middleDotsCounter = (n * 3 + 2) - 4;
        for (int i = 0; i < n / 2; i++)
        {
            string sideDots = new string('.', sideDotsCounter);
            string middleDots = new string('.', middleDotsCounter);
             Console.WriteLine("{0}*{1}*{0}", sideDots, middleDots);
             sideDotsCounter++;
             middleDotsCounter -= 2;
        }

        

        middleDotsCounter = n;
        int additionalDotsCounter1 = n / 2;
        int additionalDotsCounter2 = 0;
        sideDotsCounter = n / 2 - 1;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            string sideDots = new string('.', sideDotsCounter);
            string additionalDots1 = new string('.', additionalDotsCounter1);
            string additionalDots2 = new string('.', additionalDotsCounter2);
            string middleDots = new string('.', middleDotsCounter);
            Console.WriteLine("{0}*{1}*{2}*{3}*{2}*{1}*{0}", sideDots, additionalDots1, additionalDots2, middleDots, additionalDots2, additionalDots1, sideDots);
            additionalDotsCounter2++;
            sideDotsCounter--;
        }

        Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', n / 2), new string('.', n /2 -1), new string('.', n));

        Console.WriteLine("{0}{1}*{2}*{1}{0}", new string('*', n / 2 + 1), new string('.', n / 2), new string('.', n));

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}*{0}*{0}", new string('.', n));
        }

        Console.WriteLine("{0}{1}{0}", new string('.', n), new string('*', n + 2));
    }
}