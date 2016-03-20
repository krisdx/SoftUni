using System;

class ChristmasTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}^{0}", new string((char)39, n));

        int xOrCounter = 3;
        int charCounter = n - 1;
        for (int i = 0; i < n / 2; i++)
        {
            string chars = new string((char)39, charCounter);
            string xOrs = new string('^', xOrCounter);
            Console.WriteLine("{0}{1}{0}", chars, xOrs);
            charCounter--;
            xOrCounter += 2;
        }

        xOrCounter = 3;
        charCounter = n - 1;
        for (int i = 0; i < n / 2 + 1; i++)
        {
            string chars = new string((char)39, charCounter);
            string xOrs = new string('^', xOrCounter);
            Console.WriteLine("{0}{1}{0}", chars, xOrs);
            charCounter--;
            xOrCounter += 2;
        }

        for (int i = 0; i < n / 2 + 1; i++)
        {
            Console.WriteLine("{0}| |{0}", new string((char)39, n - 1));
        }

        Console.WriteLine(new string('-', n * 2 + 1));
    }
}