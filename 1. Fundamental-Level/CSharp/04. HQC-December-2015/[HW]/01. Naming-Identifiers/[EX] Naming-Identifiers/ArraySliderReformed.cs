using System;
using System.Linq;
using System.Numerics;

public class ArraySlider
{
    public static void Main()
    {
        string inputNumbers = Console.ReadLine();
        BigInteger[] numbers = inputNumbers
            .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
            .Select(BigInteger.Parse)
            .ToArray();
			
        long offset = 0;
        string command = Console.ReadLine();
        while (command != "stop")
        {
            string[] commandArgs = command.Split();

            long firstOperand = long.Parse(commandArgs[0]);
            string action = commandArgs[1];
            long secondOperand = long.Parse(commandArgs[2]);

            firstOperand %= numbers.Length;
            offset += firstOperand;

            long index = offset % numbers.Length;
            if (index < 0)
            {
                index += numbers.Length;
            }
            if (index >= numbers.Length)
            {
                index -= numbers.Length;
            }

            switch (action)
            {
                case "+":
                    numbers[index] = numbers[index] + secondOperand;
                    break;
                case "-":
                    numbers[index] = numbers[index] - secondOperand;
                    break;
                case "*":
                    numbers[index] = numbers[index] * secondOperand;
                    break;
                case "/":
                    numbers[index] = numbers[index] / secondOperand;
                    break;
                case "&":
                    numbers[index] = numbers[index] & secondOperand;
                    break;
                case "|":
                    numbers[index] = numbers[index] | secondOperand;
                    break;
                case "^":
                    numbers[index] = numbers[index] ^ secondOperand;
                    break;
            }

            command = Console.ReadLine();
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < 0)
            {
                numbers[i] = 0;
            }
        }

        Console.WriteLine("[" + string.Join(", ", numbers) + "]");
    }
}