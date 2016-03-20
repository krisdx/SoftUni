using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe and prints them on the console on a single line, separated by comma and space. Use spaces, commas, dots, question marks and exclamation marks as word delimiters. Print only unique palindromes, sorted lexicographically.

class Palindromes
{
    static void Main()
    {
        string[] text = Console.ReadLine().Split(new char[] { ',', ':', ';', ' ', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

        List<string> output = new List<string>();
        for (int i = 0; i < text.Length; i++)
        {
            string reversedString = Reverse(text[i]);
            if (text[i] == reversedString)
            {
                output.Add(text[i]);
            }
        }

        output.Sort();
        Console.WriteLine(string.Join(", ", output));
    }

    static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

}