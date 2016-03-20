using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that reads a list of names and prints for each name how many times it appears in the list. The names should be listed in alphabetical order. Use the input and output format from the examples below. 

class CountOfNames
{
    static void Main()
    {
        List<string> letters = new List<string>(Console.ReadLine().Split(' '));

        Dictionary<string, int> finalCount = new Dictionary<string, int>();
        letters.Sort();

        finalCount[letters[0]] = 1;
        int countTemp = 1;

        for (int i = 1; i < letters.Count; i++)
        {
            string currentLetter = letters[i];
            string previousLetter = letters[i - 1];
            if (currentLetter == previousLetter)
            {
                countTemp++;
                finalCount[letters[i]] = countTemp;
            }
            else
            {
                countTemp = 1;
                finalCount[letters[i]] = countTemp;
            }
        }

        foreach (var entry in finalCount)
        {
            Console.WriteLine("\n{0} --> {1}\n", entry.Key, entry.Value);
        }
    }
}
