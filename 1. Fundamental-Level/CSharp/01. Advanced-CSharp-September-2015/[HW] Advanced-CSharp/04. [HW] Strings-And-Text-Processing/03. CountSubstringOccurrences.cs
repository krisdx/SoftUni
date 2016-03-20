using System;

// Write a program to find how many times a given string appears in a given text as substring. The text is given at the first input line. The search string is given at the second input line. The output is an integer number. Please ignore the character casing. Overlapping between occurrences is allowed. 

class CountSubstringOccurrences
{
    static void Main()
    {
        string input = Console.ReadLine().ToLower();
        string subString = Console.ReadLine();

        int index = 0;
        int count = 0;
        while (true)
        {
            index = input.IndexOf(subString, index);
            if (index == -1)
            {
                break;
            }

            index++;
            count++;
        }

        Console.WriteLine(count);
    }
}