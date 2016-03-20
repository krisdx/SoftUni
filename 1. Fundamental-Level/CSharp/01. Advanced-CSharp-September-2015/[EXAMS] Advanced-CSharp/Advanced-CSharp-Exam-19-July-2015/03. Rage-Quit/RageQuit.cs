using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

public class RageQuit
{
    public static void Main()
    {
        string input = Console.ReadLine();

        Regex regex = new Regex(@"(.+?)(\d+)");

        StringBuilder output = new StringBuilder();
        Match match = regex.Match(input);
        while (match.Success)
        {
            string message = match.Groups[1].Value.ToUpper();
            int n = int.Parse(match.Groups[2].Value);

            for (int i = 0; i < n; i++)
            {
                output.Append(message);
            }

            match = match.NextMatch();
        }

        Console.WriteLine("Unique symbols used: {0}", 
            output.ToString().ToList().Distinct().Count());
        Console.WriteLine(output);
    }
}