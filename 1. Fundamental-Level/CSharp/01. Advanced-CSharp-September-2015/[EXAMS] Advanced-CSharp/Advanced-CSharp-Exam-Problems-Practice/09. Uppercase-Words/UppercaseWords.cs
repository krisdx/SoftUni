using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class UppercaseWords
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            inputLine = GetAndReverseUppercaseWords(inputLine);

            Console.WriteLine(SecurityElement.Escape(inputLine));

            inputLine = Console.ReadLine();
        }
    }

    public static string GetAndReverseUppercaseWords(string inputLine)
    {
        Regex regex = new Regex(@"(?<![a-zA-Z])([A-Z]+)(?![a-zA-Z])");
        MatchCollection uppercaseWords = regex.Matches(inputLine);

        for (int i = 0; i < uppercaseWords.Count; i++)
        {
            string currentWord = uppercaseWords[i].Groups[1].Value;
            string reversedWord = ReverseString(currentWord);
            if (reversedWord == currentWord)
            {
                reversedWord = DoubleWord(reversedWord);
            }

            string pattern = string.Format(@"(?<![a-zA-Z]){0}(?![a-zA-Z])", currentWord);
            inputLine = Regex.Replace(inputLine, pattern, reversedWord);
        }

        return inputLine;
    }

    public static string DoubleWord(string word)
    {
        StringBuilder doubledWord = new StringBuilder();
        for (int i = 0; i < word.Length; i++)
        {
            doubledWord.Append(word[i]).Append(word[i]);
        }

        return doubledWord.ToString();
    }

    public static string ReverseString(string currentWord)
    {
        StringBuilder reversedString = new StringBuilder();
        for (int i = currentWord.Length - 1; i >= 0; i--)
        {
            reversedString.Append(currentWord[i]);
        }

        return reversedString.ToString();
    }
}