using System;
using System.Text.RegularExpressions;

// Write a program that reads a keyword and some text from the console and prints all sentences from the text, containing that word. A sentence is any sequence of words ending with '.', '!' or '?'. 

class SentenceExtractor
{
    static void Main()
    {
        string keyWord = Console.ReadLine();
        string inputText = Console.ReadLine();

        string pattern = string.Format(@"(\w+[\s+]+)+{0}[\w+\s+]+[?!.]", keyWord);
        Regex regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(inputText);
        foreach (Match match in matches)
        {
            Console.WriteLine("{0}", match);
        }
    }
}