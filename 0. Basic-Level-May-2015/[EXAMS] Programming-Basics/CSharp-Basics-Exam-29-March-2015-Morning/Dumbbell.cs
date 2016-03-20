using System;

class Dumbbell //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}{1}{2}{1}{0}", new string('.',n / 2), new string('&', n - (n / 2)), new string('.', n));

        string middleDots = new string('.', n);
        int sideDotsCounter = n / 2 - 1;
        int asteriskCounter = n / 2;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            string sideDots = new string('.', sideDotsCounter);
            string asterisk = new string('*', asteriskCounter);
            Console.WriteLine("{0}&{1}&{2}&{1}&{0}", sideDots, asterisk, middleDots);
            asteriskCounter++;
            sideDotsCounter--;
        }

        Console.WriteLine("&{0}&{1}&{0}&", new string('*', n - 2), new string('=', n));

        sideDotsCounter = 1;
        asteriskCounter = n - 3;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            string sideDots = new string('.', sideDotsCounter);
            string asterisk = new string('*', asteriskCounter);
            Console.WriteLine("{0}&{1}&{2}&{1}&{0}", sideDots, asterisk, middleDots);
            sideDotsCounter++;
            asteriskCounter--;
        }

        Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', n / 2), new string('&', n - (n / 2)), new string('.', n));
    }
}