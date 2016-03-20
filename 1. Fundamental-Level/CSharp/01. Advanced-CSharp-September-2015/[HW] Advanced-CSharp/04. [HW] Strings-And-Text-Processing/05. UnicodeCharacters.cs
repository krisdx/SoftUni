using System;
using System.Globalization;
using System.Text;

// Write a program that converts a string to a sequence of C# Unicode character literals.

class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();

        StringBuilder output = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            output.Append("\\u" + ((int)input[i]).ToString("X4"));
        }

        Console.WriteLine(output);
    }
}