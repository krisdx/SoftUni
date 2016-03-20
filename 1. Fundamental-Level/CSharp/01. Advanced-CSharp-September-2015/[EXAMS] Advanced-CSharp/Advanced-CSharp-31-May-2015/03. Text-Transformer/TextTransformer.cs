using System;
using System.Text;
using System.Text.RegularExpressions;

public class TextTransformer
{
    static void Main()
    {
        StringBuilder input = new StringBuilder();

        string inputLine = Console.ReadLine();
        while (inputLine != "burp")
        {
            input.Append(inputLine);

            inputLine = Console.ReadLine();
        }

        string trimmedInput = Regex.Replace(input.ToString(), @"\s+", " ");

        Regex regex = new Regex(@"([&%$'])([^&%$']+)\1");
        MatchCollection matches = regex.Matches(trimmedInput);

        StringBuilder output = new StringBuilder();
        foreach (Match match in matches)
        {
            string currentWord = TransformWord(match.ToString());
            output.Append(currentWord + " ");
        }

        Console.WriteLine(output);
    }

    private static string TransformWord(string currentWord)
    {
        StringBuilder transformedWord = new StringBuilder();

        int specialSymbolValue = GetSpecialSymbolValue(currentWord[0]);
        for (int i = 0; i < currentWord.Length; i++)
        {
            if (i == 0 || i == currentWord.Length - 1)
            {
                continue;
            }

            if (i % 2 == 1)
            {
                char currentChar = currentWord[i];
                transformedWord.Append((char)(currentWord[i] + specialSymbolValue));
            }
            else
            {
                char currentChar = currentWord[i];
                transformedWord.Append((char)(currentWord[i] - specialSymbolValue));
            }
        }

        return transformedWord.ToString();
    }

    private static int GetSpecialSymbolValue(char specialSymbol)
    {
        switch (specialSymbol)
        {
            case '$':
                return 1;
            case '%':
                return 2;
            case '&':
                return 3;
            default: //'\'':
                return 4;
        }
    }
}
