using System;
using System.Linq;
using System.Numerics;

class ArraySlider
{
    static void Main()
    {
        BigInteger[] numbers = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();

        string command = Console.ReadLine();
        int index = 0;
        while (command != "stop")
        {
            string[] commandDetails = command.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int offset = int.Parse(commandDetails[0]) % numbers.Length;
            if (offset < 0)
            {
                offset += numbers.Length;
            }
            index = (index + offset) % numbers.Length;
            char operation = char.Parse(commandDetails[1]);
            int operand = int.Parse(commandDetails[2]);

            numbers = ExecuteOperation(numbers, operation, operand, index);

            command = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", string.Join(", ", numbers));
    }

    static BigInteger[] ExecuteOperation(BigInteger[] numbers, char operation, int operand, int index)
    {
        if (operation == '&')
        {
            numbers[index] &= operand;
        }
        else if (operation == '|')
        {
            numbers[index] |= operand;
        }
        else if (operation == '^')
        {
            numbers[index] ^= operand;
        }
        else if (operation == '+')
        {
            numbers[index] += operand;
        }
        else if (operation == '-')
        {
            numbers[index] -= operand;
        }
        else if (operation == '*')
        {
            numbers[index] *= operand;
        }
        else if (operation == '/')
        {
            numbers[index] /= operand;
        }

        if (numbers[index] < 0)
        {
            numbers[index] = 0;
        }

        return numbers;
    }
}