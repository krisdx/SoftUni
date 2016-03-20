using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class CognateWords
{
    static void Main()
    {
        string input = Console.ReadLine();

        Regex regex = new Regex(@"[a-zA-Z]+");
        MatchCollection matches = regex.Matches(input);
        string[] words = new string[matches.Count];
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = matches[i].ToString();
        }

        HashSet<string> uniqueWords = new HashSet<string>();
        bool solutionFound = false;
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                for (int k = 0; k < words.Length; k++)
                {
                    if (words[i] + words[j] == words[k])
                    {
                        if (!uniqueWords.Contains(words[k]))
                        {
                            uniqueWords.Add(words[k]);
                            Console.WriteLine("{0}|{1}={2}", words[i], words[j], words[k]);
                        }

                        solutionFound = true;
                    }
                }
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }
}