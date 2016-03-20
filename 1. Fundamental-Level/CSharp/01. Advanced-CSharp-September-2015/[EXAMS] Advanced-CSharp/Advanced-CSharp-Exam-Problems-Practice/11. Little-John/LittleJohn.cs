using System;
using System.Text;
using System.Text.RegularExpressions;

class LittleJohn
{
    static void Main()
    {
        Regex regex = new Regex(@">>>----->>|>>----->|>----->");

        int smallArrowsCount = 0;
        int mediumArrowsCount = 0;
        int largeArrowsCount = 0;
        for (int i = 0; i < 4; i++)
        {
            string inputLine = Console.ReadLine();

            MatchCollection arrows = regex.Matches(inputLine);
            foreach (var arrow in arrows)
            {
                switch (arrow.ToString())
                {
                    case ">----->": smallArrowsCount++;
                        break;
                    case ">>----->": mediumArrowsCount++;
                        break;
                    case ">>>----->>": largeArrowsCount++;
                        break;
                }
            }
        }

        string numberInString = string.Empty + smallArrowsCount + mediumArrowsCount + largeArrowsCount;
        long numberInLong = long.Parse(numberInString);
        string binaryRepresentation = Convert.ToString(numberInLong, 2);
        long resultNum = GetNumber(binaryRepresentation);

        Console.WriteLine(resultNum);
    }

    static long GetNumber(string binaryRepresentation)
    {
        StringBuilder result = new StringBuilder();
        for (int i = binaryRepresentation.Length - 1; i >= 0; i--)
        {
            result.Append(binaryRepresentation[i]);
        }
        string resultInstring = binaryRepresentation + result.ToString();

        return Convert.ToInt64(resultInstring, 2);
    }
}