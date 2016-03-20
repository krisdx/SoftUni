using System;
using System.Text.RegularExpressions;

class ValidUsernames
{
    static void Main() 
    {
        string input = Console.ReadLine();

        Regex regex = new Regex(@"\b[a-zA-Z]\w{3,25}\b");
        MatchCollection validUsersNames = regex.Matches(input);

        int maxSum = int.MinValue;
        int firstUserNameWithLongestLength = 0;
        int secondUserNameWithLongesLength = 0;
        for (int i = 0; i < validUsersNames.Count - 1; i++)
        {
            int currentLength1 = validUsersNames[i].Length;
            int currentLength2 = validUsersNames[i + 1].Length;

            int currentSum = currentLength1 + currentLength2;
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                firstUserNameWithLongestLength = i;
                secondUserNameWithLongesLength = i + 1;
            }
        }

        Console.WriteLine(validUsersNames[firstUserNameWithLongestLength]);
        Console.WriteLine(validUsersNames[secondUserNameWithLongesLength]);
    }
}