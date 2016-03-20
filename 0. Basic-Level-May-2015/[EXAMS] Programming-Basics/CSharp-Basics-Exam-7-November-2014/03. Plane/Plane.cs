using System;

class Plane
{
    static void Main() //-k.d
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('.', ((n * 3) - 1) / 2) + '*' + new string('.', ((n * 3) - 1) / 2));

        int sideDotsConter = ((n * 3) - 3) / 2;
        int middleDotsCounter = 1;
        for (int i = 0; i < n / 2 + 2; i++)
        {
            string sideDots = new string('.', sideDotsConter);
            string middleDots = new string('.', middleDotsCounter);
            Console.WriteLine(sideDots + '*' + middleDots + '*' + sideDots);
            sideDotsConter--;
            middleDotsCounter += 2;
        }

        sideDotsConter = n - 4;
        middleDotsCounter = n* 3 - ((sideDotsConter * 2) + 2);
        for (int i = 0; i < n / 2 - 1; i++)
        {
            string sideDots = new string('.', sideDotsConter);
            string middleDots = new string('.', middleDotsCounter);
            Console.WriteLine(sideDots + '*'+ middleDots + '*'+ sideDots);
            sideDotsConter -= 2;
            middleDotsCounter += 4;
        }

        Console.WriteLine('*' + new string('.', n - 2) + '*' + new string('.', n) + '*' + new string('.', n - 2) + '*');


        sideDotsConter = n - 4;
        int additionalDotsCounter = 1;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            string sideDots = new string('.', sideDotsConter);
            string additionalDots = new string('.', additionalDotsCounter);
            string middleDots = new string('.', n);
            Console.WriteLine('*' + sideDots + '*' + additionalDots + '*' + middleDots + '*' + additionalDots + '*' + sideDots + '*');
            additionalDotsCounter += 2;
            sideDotsConter -= 2;
        }

        sideDotsConter = n - 1;
        middleDotsCounter = n;
        for (int i = 0; i < n - 1; i++)
        {
            string sideDots = new string('.', sideDotsConter);
            string middleDots = new string('.', middleDotsCounter);
            Console.WriteLine(sideDots + '*' + middleDots + '*' + sideDots);
            middleDotsCounter += 2;
            sideDotsConter--;
        }
        Console.WriteLine(new string('*', n * 3));
    }
}