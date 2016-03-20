using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main()
    {
        StringBuilder HTML = new StringBuilder();
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            HTML.Append(inputLine);

            inputLine = Console.ReadLine();
        }

        Regex regex = new Regex(@"<\s*a\s*[^>]*href\s*=([""'\s])*(.+?)\1");
        Match match = regex.Match(HTML.ToString());
        while (match.Success)
        {
            Console.WriteLine(match.Groups[2]);
            match = match.NextMatch();
        }
    }
}