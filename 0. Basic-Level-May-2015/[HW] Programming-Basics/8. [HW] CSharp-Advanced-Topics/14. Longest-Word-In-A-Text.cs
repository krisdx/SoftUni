using System;
using System.Collections.Generic;
using System.Linq;

// Write a program to find the longest word in a text. 

class LongestWordInAText
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] allWords = input.Split(new char[] { ' ', ',', ':', ';', '.' },
                                                StringSplitOptions.RemoveEmptyEntries);

        int longestWordIndex = 0;
        for (int i = 1; i < allWords.Length; i++)
        {
            if (allWords[i].Length > allWords[longestWordIndex].Length)
            {
                longestWordIndex = i;
            }
        }

        Console.WriteLine(allWords[longestWordIndex]);
    }
}