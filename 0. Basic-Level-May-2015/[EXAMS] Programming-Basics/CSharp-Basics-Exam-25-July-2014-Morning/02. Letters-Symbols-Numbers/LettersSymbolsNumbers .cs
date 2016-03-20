using System;

class LettersSymbolsNumbers //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        long symbolsSum = 0;
        long lettersSum = 0;
        long digitsSum = 0;
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            for (int ch = 0; ch < input.Length; ch++)
            {
                if (char.IsLetter(input[ch]))
                {
                    char currentChar = char.ToLower(input[ch]);
                    lettersSum += (currentChar - ('a' - 1)) * 10;
                }
                else if (char.IsDigit(input[ch]))
                {
                    digitsSum += (int)char.GetNumericValue(input[ch]) * 20;
                }
                else if (input[ch] == ' ' || input[ch] == '\t' || input[ch] == '\r' || input[ch] == '\n')
                {
                    continue;
                }
                else
                {
                    symbolsSum += 200;
                }
            }
        }

        Console.WriteLine(lettersSum);
        Console.WriteLine(digitsSum);
        Console.WriteLine(symbolsSum);
    }
}