using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class BiggestTableRow
{
    static void Main()
    {
        Regex regex = new Regex(@"<td>(.+?)<\/td>");

        List<decimal> rowWithMaxSum = new List<decimal>();
        rowWithMaxSum.Add(decimal.MinValue);

        bool hasData = false;
        string row = Console.ReadLine();
        while (row != "</table>")
        {
            MatchCollection matches = regex.Matches(row);
            decimal n;
            List<decimal> currentRowSum =new List<decimal>();
            for (int i = 0; i < matches.Count; i++)
            {
                string item = matches[i].Groups[1].Value;
                if (decimal.TryParse(item, out n))
                {
                    currentRowSum.Add(n);
                    hasData = true;
                }
            }

            if (currentRowSum.Sum() > rowWithMaxSum.Sum() && hasData)
            {
                rowWithMaxSum = currentRowSum.ToList();
            }

            row = Console.ReadLine();
        }

        if (!hasData)
        {
            Console.WriteLine("no data");
            return;
        }

        Console.WriteLine("{0:0.##} = {1}", rowWithMaxSum.Sum(), string.Join(" + ", rowWithMaxSum));
    }
}