using System;

// Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with *. Print the resulting string on the console.   

class StringLength
{
    static void Main()
    {
        string input = Console.ReadLine();

        string outputText = input;
        if (input.Length < 20)
        {
            for (int i = input.Length; i < 20; i++)
            {
                outputText += '*';
            }

            Console.WriteLine(outputText);
        }
        else
        {
            Console.WriteLine(outputText.Substring(0, 20));
        }
    }
}