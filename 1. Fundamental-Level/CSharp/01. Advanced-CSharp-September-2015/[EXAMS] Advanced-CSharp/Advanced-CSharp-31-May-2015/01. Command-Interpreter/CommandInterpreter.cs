using System;
using System.Collections.Generic;
using System.Linq;

public class CommandInterpreter
{
    static void Main()
    {
        string[] elements = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        string command = Console.ReadLine();
        while (command != "end")
        {
            string[] commandDetails = command.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            switch (commandDetails[0])
            {
                case "reverse":
                    {
                        int startIndex = int.Parse(commandDetails[2]);
                        int count = int.Parse(commandDetails[4]);

                        bool areCommandParamValid = ValidateCommandParams(elements, startIndex, count);
                        if (!areCommandParamValid)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        elements = ReverseNumbersInGivenRange(elements, startIndex, count);
                        break;
                    }
                case "sort":
                    {
                        int startIndex = int.Parse(commandDetails[2]);
                        int count = int.Parse(commandDetails[4]);

                        bool areCommandParamValid = ValidateCommandParams(elements, startIndex, count);
                        if (!areCommandParamValid)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        elements = SortNumbersInGivenRange(elements, startIndex, count);
                        break;
                    }
                case "rollLeft":
                    {
                        int n = int.Parse(commandDetails[1]);
                        elements = RollNumbersToLeft(elements, n);
                        break;
                    }
                case "rollRight":
                    {
                        int n = int.Parse(commandDetails[1]);
                        elements = RollNumbersToRight(elements, n);
                        break;
                    }
            }

            command = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", string.Join(", ", elements));
    }

    private static bool ValidateCommandParams(string[] elements, int startIndex, int count)
    {
        if (startIndex < 0 || startIndex > elements.Length - 1)
        {
            return false;
        }

        if (count < 0 || count > elements.Length)
        {
            return false;
        }

        if ((startIndex + count) - 1 > elements.Length - 1)
        {
            return false;
        }

        return true;
    }

    private static string[] RollNumbersToRight(string[] elements, int n)
    {
        List<string> rolledNumbers = elements.ToList();
        for (int i = 0; i < n; i++)
        {
            string lastNum = rolledNumbers.Last();
            rolledNumbers.Remove(rolledNumbers.Last());
            rolledNumbers.Insert(0, lastNum);
        }

        return rolledNumbers.ToArray();
    }

    private static string[] RollNumbersToLeft(string[] elements, int n)
    {
        List<string> rolledNumbers = elements.ToList();
        for (int i = 0; i < n; i++)
        {
            string firstNum = rolledNumbers.First();
            rolledNumbers.Remove(rolledNumbers.First());
            rolledNumbers.Add(firstNum);
        }

        return rolledNumbers.ToArray();
    }

    private static string[] SortNumbersInGivenRange(string[] elements, int startIndex, int count)
    {
        List<string> sortedNumbers = new List<string>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            sortedNumbers.Add(elements[i]);
        }

        sortedNumbers.Sort();

        int index = 0;
        for (int i = startIndex; i < startIndex + count; i++)
        {
            elements[i] = sortedNumbers[index];
            index++;
        }

        return elements;
    }

    private static string[] ReverseNumbersInGivenRange(string[] elements, int startIndex, int count)
    {
        List<string> reversedNumbers = new List<string>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            reversedNumbers.Add(elements[i]);
        }

        reversedNumbers.Reverse();

        int index = 0;
        for (int i = startIndex; i < startIndex + count; i++)
        {
            elements[i] = reversedNumbers[index];
            index++;
        }

        return elements;
    }
}