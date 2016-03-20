using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class QueryMess
{
    static void Main()
    {
        Regex regex = new Regex(@"([!@#\w:\/*\-.%()^\s]+)=([!@#\w:\/*\-.%()^\s]+)");

        var line = Console.ReadLine();
        while (line != "END")
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            line = Regex.Replace(line, @"%20|\+", " ");
            line = Regex.Replace(line, @"\s{2,}", " ");

            MatchCollection matches = regex.Matches(line);
            for (int i = 0; i < matches.Count; i++)
            {
                string field = matches[i].Groups[1].Value.Trim();
                string value = matches[i].Groups[2].Value.Trim();

                if (dictionary.ContainsKey(field))
                {
                    dictionary[field].Add(value);
                }
                else
                {
                    List<string> currentValue = new List<string>() { value };
                    dictionary.Add(field, currentValue);
                }
            }

            Print(dictionary);

            line = Console.ReadLine();
        }

    }

    public static void Print(Dictionary<string, List<string>> dictionary)
    {
        foreach (var fieldAndValue in dictionary)
        {
            Console.Write("{0}=", fieldAndValue.Key);
            Console.Write('[');
            int counter = 0;
            for (int i = 0; i < fieldAndValue.Value.Count; i++)
            {
                if (counter != fieldAndValue.Value.Count - 1)
                {
                    Console.Write("{0}, ", fieldAndValue.Value[i]);
                }
                else
                {
                    Console.Write(fieldAndValue.Value[i]);
                }

                counter++;
            }
            Console.Write(']');
        }
        Console.WriteLine();
    }
}