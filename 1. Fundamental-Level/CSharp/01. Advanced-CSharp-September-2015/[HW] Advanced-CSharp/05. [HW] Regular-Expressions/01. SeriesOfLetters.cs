using System;
using System.Text.RegularExpressions;

// Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.

class SeriesOfLetters
{
    static void Main()
    {
        string inputText = Console.ReadLine();

        string outputText = inputText;
        for (int i = 0; i < outputText.Length; i++)
        {
            string pattern = string.Format(@"{0}+", outputText[i]);
            Regex regex = new Regex(pattern);
            outputText = regex.Replace(outputText, outputText[i].ToString());
        }

        Console.WriteLine(outputText);
    }
}