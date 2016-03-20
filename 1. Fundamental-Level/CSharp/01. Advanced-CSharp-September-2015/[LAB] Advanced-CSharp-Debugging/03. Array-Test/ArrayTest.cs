using System;
using System.Linq;
using System.Numerics;

class ArrayTest
{
    static void Main()
    {
        int arraySize = int.Parse(Console.ReadLine());
        BigInteger[] numbers = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();

        string command = Console.ReadLine();
        while (!command.Equals("stop"))
        {
            string[] commandDetails = command.Split();
            string action = commandDetails[0];

            int index = 0;
            BigInteger value = 0;

            if (action.Equals("add") ||
                    action.Equals("subtract") ||
                    action.Equals("multiply"))
            {
                index = int.Parse(commandDetails[1]);
                value = BigInteger.Parse(commandDetails[2]);
            }

            PerformAction(numbers, action, index, value);

            PrintArray(numbers);

            command = Console.ReadLine();
        }
    }

    static BigInteger[] PerformAction(BigInteger[] numbers, string action, int index, BigInteger value)
    {
        switch (action)
        {
            case "multiply":
                numbers[index - 1] *= value;
                break;
            case "add":
                numbers[index - 1] += value;
                break;
            case "subtract":
                numbers[index - 1] -= value;
                break;
            case "lshift":
                ArrayShiftLeft(numbers);
                break;
            case "rshift":
                ArrayShiftRight(numbers);
                break;
        }

        return numbers;
    }

    static void ArrayShiftRight(BigInteger[] numbers)
    {
        BigInteger lastNum = numbers[numbers.Length - 1];
        for (int i = numbers.Length - 1; i >= 1; i--)
        {
            numbers[i] = numbers[i - 1];
        }
        numbers[0] = lastNum;
    }

    static void ArrayShiftLeft(BigInteger[] numbers)
    {
        BigInteger firstNum = numbers[0];
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            numbers[i] = numbers[i + 1];
        }
        numbers[numbers.Length - 1] = firstNum;
    }

    static void PrintArray(BigInteger[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();
    }
}