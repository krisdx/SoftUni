using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string inputText = Console.ReadLine();

        Regex regex = new Regex(@"\w+[.-_]*\w+@[\w+.-]+");   
        MatchCollection matches = regex.Matches(inputText);

        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }
    }
}