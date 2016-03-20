using System;
using System.Collections.Generic;

class ValidUsernames
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<string> userNames = GetUsers(input);
        int maxSum = int.MinValue;
        int firstUserWithLongestLength = 0;
        int secondUserWithLongesLength = 1;
        for (int i = 0; i < userNames.Count - 1; i++)
        {
            int currentLength1 = userNames[i].Length;
            int currentLength2 = userNames[i + 1].Length;

            int currentSum = currentLength1 + currentLength2;
            if (currentSum >= maxSum)
            {
                maxSum = currentSum;
                firstUserWithLongestLength = i;
                secondUserWithLongesLength = i + 1;
            }
        }

        Console.WriteLine("{0}\n{1}", userNames[firstUserWithLongestLength], userNames[secondUserWithLongesLength]);
    }

    static List<string> GetUsers(string input)
    {
        List<string> userNames = new List<string>();

        string userName = string.Empty;
        int counter = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetterOrDigit(input[i]) || input[i] == '_')
            {
                counter++;
                userName += input[i];
            }
            else
            {
                if (counter > 3 && counter < 25)
                {
                    userNames.Add(userName);
                }
                counter = 0;
                userName = string.Empty;
            }
        }

        return userNames;
    }
}