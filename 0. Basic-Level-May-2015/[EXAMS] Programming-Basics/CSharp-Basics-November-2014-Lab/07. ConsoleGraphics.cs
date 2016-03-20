using System;

class ConsoleGraphics //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('*', n * 2));
        Console.WriteLine(new string('*', n * 2));
        for (int i = 0; i < n - 1; i++)
        {
            Console.Write(new string('*', (n * 2 - (n - 1)) / 2));
            Console.Write(new string(' ', n - 1));
            Console.WriteLine(new string('*', (n * 2 - (n - 1)) / 2));
        }
        Console.WriteLine(new string('~', n * 2));
        Console.WriteLine(new string('~', n * 2));
    }
}