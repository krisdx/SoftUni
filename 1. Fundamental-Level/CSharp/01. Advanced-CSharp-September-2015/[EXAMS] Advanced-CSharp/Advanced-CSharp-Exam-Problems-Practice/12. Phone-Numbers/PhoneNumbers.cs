using System;
using System.Text;
using System.Text.RegularExpressions;

public class PhoneNumbers
{
    static void Main()
    {
        StringBuilder input = new StringBuilder();
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            input.Append(inputLine);

            inputLine = Console.ReadLine();
        }

        Regex regex = new Regex(@"([A-Z][a-zA-Z]*)[^a-zA-Z+]*?(\+*\d[\d.,\s\/\-()]*\d)");
        MatchCollection matches = regex.Matches(input.ToString());

        if (matches.Count == 0)
        {
            Console.WriteLine("<p>No matches!</p>");
        }
        else
        {
            Console.Write("<ol>");
            for (int i = 0; i < matches.Count; i++)
            {
                var name = matches[i].Groups[1].Value;
                var phone = Regex.Replace(matches[i].Groups[2].Value, @"[^0-9+]+", string.Empty);

                Console.Write("<li><b>{0}:</b> {1}</li>", name, phone);
            }
            Console.WriteLine("</ol>");
        }
    }
}