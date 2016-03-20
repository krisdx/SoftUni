using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

public class ThirdProblem
{
    public static void Main()
    {
        Dictionary<string, SortedList<string, bool>> variableTypes = new Dictionary<string, SortedList<string, bool>>();
        variableTypes.Add("Doubles", new SortedList<string, bool>());
        variableTypes.Add("Ints", new SortedList<string, bool>());

        //  StringBuilder inputCode = new StringBuilder();
        Regex regex = new Regex(@"(int|double)\b\s*([a-zA-Z]+)");

        bool areInScope = true;
        string line = Console.ReadLine();
        while (line != "//END_OF_CODE")
        {
            //inputCode.AppendLine(line);
            if (line.Contains("{"))
            {
                areInScope = true;
                continue;
            }
            else if (line.Contains("}"))
            {
                areInScope = false;
                continue;
            }

            Match match = regex.Match(line);
            if (areInScope)
            {
                if (match.Captures[1].Value == "Ints")
                {
                    variableTypes["Ints"].Add(match.Captures[2].Value, true);
                }
                else
                {
                    variableTypes["Doubles"].Add(match.Captures[2].Value, true);
                }
            }
            else
            {
                if (match.Captures[1].Value == "int")
                {
                    variableTypes["Ints"].Add(match.Captures[2].Value, false);
                }
                else
                {
                    variableTypes["Doubles"].Add(match.Captures[2].Value, false);
                }
            }

            line = Console.ReadLine();
        }

        var uniqueVariables = variableTypes.Where(x => x.Value.Values[0] == false);

        //MatchCollection matches = regex.Matches(inputCode.ToString());
        //for (int i = 0; i < matches.Count; i++)
        //{
        //    if (matches[i].Groups[1].Value == "int")
        //    {
        //        variableTypes["Ints"].Add(matches[i].Groups[2].Value);
        //    }
        //    else
        //    {
        //        variableTypes["Doubles"].Add(matches[i].Groups[2].Value);
        //    }
        //}


        //foreach (var variableList in variableTypes)
        //{
        //    Console.Write("{0}: ", variableList.Key);

        //    variableList.Value.Sort();
        //    if (variableList.Value.Count == 0)
        //    {
        //        Console.WriteLine("None");
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0}", string.Join(", ", variableList.Value));
        //    }
        //}
    }
}