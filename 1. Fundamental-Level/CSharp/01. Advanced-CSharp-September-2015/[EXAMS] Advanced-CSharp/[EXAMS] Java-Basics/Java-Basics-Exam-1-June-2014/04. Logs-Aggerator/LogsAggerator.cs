using System;
using System.Collections.Generic;
using System.Linq;

class LogsAggerator
{
    static void Main()
    {
        int logsCount = int.Parse(Console.ReadLine());


        SortedDictionary<string, SortedDictionary<string, int>> userLogs = new SortedDictionary<string, SortedDictionary<string, int>>();
        for (int i = 0; i < logsCount; i++)
        {
            string[] userLogDetails = Console.ReadLine().Split();
            string IP = userLogDetails[0];
            string user = userLogDetails[1];
            int duration = int.Parse(userLogDetails[2]);

            if (userLogs.ContainsKey(user))
            {
                if (userLogs[user].ContainsKey(IP))
                {
                    userLogs[user][IP] += duration;
                }
                else
                {
                    userLogs[user].Add(IP, duration);
                }
            }
            else
            {
                SortedDictionary<string, int> IPAndDuration = new SortedDictionary<string, int>{
                    {IP, duration}
                };

                userLogs.Add(user, IPAndDuration);
            }
        }

        PrintUserLogs(userLogs);
    }

    static void PrintUserLogs(SortedDictionary<string, SortedDictionary<string, int>> userLogs)
    {
        foreach (var user in userLogs)
        {
            Console.Write("{0}: ", user.Key);
            int maxDuration = 0;
            foreach (var durationTime in user.Value)
            {
                maxDuration += durationTime.Value;
            }
            Console.Write("{0} [", maxDuration);
            int length = user.Value.Count;
            int counter = 0;
            foreach (var IP in user.Value)
            {
                counter++;
                if (counter != length)
                {
                    Console.Write("{0}, ", IP.Key);
                }
                else
                {
                    Console.Write("{0}]", IP.Key);
                }
            }
            Console.WriteLine();
        }
    }
}
