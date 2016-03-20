using System;

class KingOfThieves // -k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char gemSymbol = char.Parse(Console.ReadLine());

        int linesCount = n / 2;
        int symbolsCount = 1;
        for (int i = 0; i < n / 2 + 1; i++)
        {
            string symbols = new string(gemSymbol, symbolsCount);
            string lines = new string('-', linesCount);
            Console.WriteLine(lines + symbols + lines);
            linesCount--;
            symbolsCount += 2;
        }

        symbolsCount = n - 2;
        linesCount = 1;
        for (int i = 0; i < n / 2; i++)
        {
            string symbols = new string(gemSymbol, symbolsCount);
            string lines = new string('-', linesCount);
            Console.WriteLine(lines + symbols + lines);
            linesCount++;
            symbolsCount -= 2;
        }
    }
}
