using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class UserLogs
{
    static void Main()
    {
        string input = Console.ReadLine();

        SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();
        while (input != "end")
        {
            string IP = GetIP(input);
            string user = GetUser(input);

            if (users.ContainsKey(user))
            {
                if (users[user].ContainsKey(IP))
                {
                    users[user][IP]++;
                }
                else
                {
                    users[user].Add(IP, 1);
                }
            }
            else
            {
                Dictionary<string, int> IPAdress = new Dictionary<string, int>()
                {
                    {IP, 1}
                };
                users.Add(user, IPAdress);
            }

            input = Console.ReadLine();
        }

        Print(users);
    }

    static string GetIP(string input)
    {
        string IPv4Pattern = @"\d+\.\d+\.\d+\.\d+";
        Regex regexV4 = new Regex(IPv4Pattern);
        string IPv6Pattern = @"\w+:\w+:\w+:\w+:\w+:\w+:\w+:\w+";
        Regex regexV6 = new Regex(IPv6Pattern);

        Match IP;
        bool isIPv4 = regexV4.IsMatch(input);
        if (isIPv4)
        {
            IP = regexV4.Match(input);
        }
        else
        {
            IP = regexV6.Match(input);
        }

        return IP.ToString();
    }

    static string GetUser(string input)
    {
        string userPattern = @"user=(?<user>\w+)";
        Regex userRegex = new Regex(userPattern);
        Match userMatch = userRegex.Match(input);
        string user = userMatch.Groups[1].ToString();

        return user;
    }

    static void Print(SortedDictionary<string, Dictionary<string, int>> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine("{0}:", user.Key);
            int maxLength = users[user.Key].Count;
            int currentLength = 1;
            foreach (var IP in user.Value)
            {
                if (currentLength == maxLength)
                {
                    Console.Write("{0} => {1}.", IP.Key, IP.Value);
                }
                else
                {

                    Console.Write("{0} => {1}, ", IP.Key, IP.Value);
                }

                currentLength++;
            }
            Console.WriteLine();
        }
    }
}