using System;
using System.Collections.Generic;

// Write a program that reads an array of strings and finds in it all sequences of equal elements (comparison should be case-sensitive). The input strings are given as a single line, separated by a space. 

class SequencesOfEqualStrings
{
    static void Main()
    {
        string[] input = Console.ReadLine().Trim().Split();

        int counter = 0;
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input.Length; j++)
            {
                if (input[i] == input[j])
                {
                    counter++;
                }
            }

            if (counter <= 1)
            {
                Console.WriteLine(input[i]);
            }
            else
            {
                for (int k = 0; k < counter; k++)
                {
                    Console.Write(input[i] + " ");
                }
                Console.WriteLine();

                i += counter - 1;
            }

            counter = 0;
        }
    }
}