using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class OhMyGirlS
{
    static void Main()
    {
        string key = Console.ReadLine();

        StringBuilder input = new StringBuilder();
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            input.Append(inputLine);

            inputLine = Console.ReadLine();
        }

        string pattern = GetPattern(key);
        Regex regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(input.ToString());
        foreach (Match match in matches)
        {
            Console.Write(match.Groups[2]);
        }
    }

    private static string GetPattern(string key)
    {
        StringBuilder pattern = new StringBuilder();

        pattern.Append(key[0]);

        for (int i = 1; i < key.Length - 1; i++)
        {
            if (char.IsDigit(key[i]))
            {
                pattern.AppendFormat(@"[0-9]*");
            }
            else if (char.IsLetter(key[i]))
            {
                pattern.AppendFormat(@"[a-zA-Z]*");
            }
            else
            {
                pattern.AppendFormat(@"{0}*", key[i]);
            }
        }

        pattern.Append(key[key.Length - 1]);

        return string.Format("({0})", pattern.ToString()) + @"(.{2,6}?)" + string.Format("({0})", pattern.ToString());
    }
}