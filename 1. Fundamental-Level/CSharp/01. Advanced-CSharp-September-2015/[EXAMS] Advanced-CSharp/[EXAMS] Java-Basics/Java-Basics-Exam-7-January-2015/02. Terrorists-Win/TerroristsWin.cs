using System;
using System.Collections.Generic;
using System.Linq;

class TerroristsWin
{
    static void Main()
    {
        string inputText = Console.ReadLine();

        char[] outputText = inputText.ToCharArray();
        for (int i = 0; i < outputText.Length; i++)
        {
            if (outputText[i] == '|')
            {
                int index = i;
                outputText[index] = '.';
                index++;
                int sum = 0;
                while (outputText[index] != '|')
                {
                    sum += outputText[index];
                    outputText[index] = '.';
                    index++;
                }
                outputText[index] = '.';

                int bombPower = sum % 10;

                // clearing left characters
                for (int leftCol = i - 1; leftCol >= i - bombPower; leftCol--)
                {
                    if (leftCol < 0)
                    {
                        break;
                    }
                    outputText[leftCol] = '.';
                }

                // clearing right characters
                for (int rightCol = index + 1; rightCol <= index + bombPower; rightCol++)
                {
                    if (rightCol >= outputText.Length)
                    {
                        break;
                    }
                    outputText[rightCol] = '.';
                }
            }
        }

        PrintText(outputText);
    }

    private static void PrintText(char[] outputText)
    {
        foreach (char letter in outputText)
        {
            Console.Write(letter);
        }
        Console.WriteLine();
    }
}