using System;
using System.Collections.Generic;

class SpyHard // -k.dS
{
    static void Main()
    {
        string key = Console.ReadLine();
        string message = Console.ReadLine();

        int charSum = 0;
        for (int i = 0; i < message.Length; i++)
        {
            char currentChar = message[i];
            if (char.IsLetter(currentChar))
            {
                if (char.IsLower(currentChar))
                {
                    charSum += currentChar - ('a' - 1);
                }
                else
                {
                    charSum += currentChar - ('A' - 1);
                }
            }
            else
            {
                charSum += currentChar;
            }
        }

        int reminder = 0;
        int numeralSystem = int.Parse(key);
        List<string> result = new List<string>();
        while (charSum > 0)
        {
            reminder = charSum % numeralSystem;
            result.Add(Convert.ToString(reminder));
            charSum /= numeralSystem;
        }

        result.Reverse();
        int symbolCounter = message.Length;
        Console.Write(key + symbolCounter);
        foreach (var symbol in result)
        {
            Console.Write(symbol);
        }
    }
}