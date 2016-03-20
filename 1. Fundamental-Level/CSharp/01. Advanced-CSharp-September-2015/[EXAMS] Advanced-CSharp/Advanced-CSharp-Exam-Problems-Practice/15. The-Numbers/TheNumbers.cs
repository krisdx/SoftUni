using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class TheNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();

        int[] numbers = TrimInput(input);

        string[] numbersInHex = new string[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            StringBuilder currentNum = new StringBuilder();
            currentNum.Append("0x");
            currentNum.Append(Convert.ToString(numbers[i], 16).ToUpper().PadLeft(4, '0'));
            if (i + 1 != numbers.Length)
            {
                currentNum.Append('-');
            }

            numbersInHex[i] = currentNum.ToString();
        }

        Console.WriteLine(string.Join(string.Empty, numbersInHex));
    }

    public static int[] TrimInput(string input)
    {
        StringBuilder trimmedInput = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                trimmedInput.Append(input[i]);
            }
            else
            {
                trimmedInput.Append(' ');
            }
        }

        int[] numbers = trimmedInput.ToString().Split(new char[] { ' ', 't' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        return numbers;
    }
}