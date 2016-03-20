using System;
using System.Collections.Generic;

// Write a program that reads some text from the console and counts the occurrences of each character in it. Print the results in alphabetical (lexicographical) order. 

class CountSymbols
{
    static void Main()
    {
        string inputText = Console.ReadLine();

        SortedDictionary<char, int> sortedSet = new SortedDictionary<char, int>();
        foreach (char letter in inputText)
        {
            if (sortedSet.ContainsKey(letter))
            {
                sortedSet[letter]++;
            }
            else
            {
                sortedSet.Add(letter, 1);
            }
        }

        foreach (KeyValuePair<char, int> pair in sortedSet)
        {
            Console.WriteLine("{0}: {1} time/s", pair.Key, pair.Value);
        }
    }
}