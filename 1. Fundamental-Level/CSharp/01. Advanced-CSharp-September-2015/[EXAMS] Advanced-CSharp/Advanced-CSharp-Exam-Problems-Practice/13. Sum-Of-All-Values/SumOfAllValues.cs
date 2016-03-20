using System;
using System.Linq;
using System.Text.RegularExpressions;

class SumOfAllValues
{
    static void Main()
    {
        string[] keys = GetKeys(Console.ReadLine());
        if (keys[0] == null || keys[0] == string.Empty ||
           keys[1] == null || keys[1] == string.Empty)
        {
            Console.WriteLine("<p>A key is missing</p>");
            return;
        }
        string text = Console.ReadLine();

        string pattern = string.Format(@"{0}\s*(\d*\.*\d*)\s*{1}", keys[0], keys[1]);
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        decimal sum = 0;
        for (int i = 0; i < matches.Count; i++)
        {
            sum += decimal.Parse(matches[i].Groups[1].ToString());
        }

        if (sum == 0)
        {
            Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
        }
        else
        {
            Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum);
        }
    }

    public static string[] GetKeys(string input)
    {
        Regex startKey = new Regex(@"(^[a-zA-Z_]+)\d");
        Regex endKey = new Regex(@"\d([a-zA-Z_]+$)");

        string[] keys = new string[2];
        keys[0] = startKey.Match(input).Groups[1].Value;
        keys[1] = endKey.Match(input).Groups[1].Value;

        return keys;
    }
}