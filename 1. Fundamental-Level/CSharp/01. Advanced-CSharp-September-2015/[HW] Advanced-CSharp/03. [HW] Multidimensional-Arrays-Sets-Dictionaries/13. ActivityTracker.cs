using System;
using System.Collections.Generic;

class ActivityTracker
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        SortedDictionary<int, SortedDictionary<string, double>> activityData = new SortedDictionary<int, SortedDictionary<string, double>>();

        for (int i = 0; i < n; i++)
        {
            string[] activityDetails = Console.ReadLine().Split(new char[] { ' ', '/' });
            int month = int.Parse(activityDetails[1]);
            string user = activityDetails[3];
            double distance = double.Parse(activityDetails[4]);

            if (activityData.ContainsKey(month))
            {
                if (activityData[month].ContainsKey(user))
                {
                    activityData[month][user] += distance;
                }
                else
                {
                    activityData[month].Add(user, distance);
                }
            }
            else
            {
                SortedDictionary<string, double> newUserActivityData = new SortedDictionary<string, double>()
                {
                    { user, distance }
                };

                activityData.Add(month, newUserActivityData);
            }
        }

        PrintResult(activityData);
    }

    private static void PrintResult(SortedDictionary<int, SortedDictionary<string, double>> activityData)
    {
        foreach (var month in activityData)
        {
            Console.Write("{0}: ", month.Key);
            bool isFirst = true;
            foreach (var user in month.Value)
            {
                if (isFirst)
                {
                    Console.Write("{0}({1})", user.Key, user.Value);
                    isFirst = false;
                }
                else
                {
                    Console.Write(", {0}({1})", user.Key, user.Value);
                }
            }
            Console.WriteLine();
        }
    }
}