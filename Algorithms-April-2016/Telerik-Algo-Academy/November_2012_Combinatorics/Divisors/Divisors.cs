using System;
using System.Collections.Generic;
using System.Linq;

public class Divisores
{
    private static int minDivisorsCount = int.MaxValue;
    private static int resultNumber = int.MinValue;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        byte[] digits = new byte[n];
        bool[] used = new bool[n];
        for (int i = 0; i < n; i++)
        {
            digits[i] = byte.Parse(Console.ReadLine());
        }

        byte[] digitsCopy = new byte[n];
        GeneratePermutations(digits, digitsCopy, used);
        Console.WriteLine(resultNumber);
    }

   private static void GeneratePermutations(
       byte[] digits, byte[] digitsCopy, bool[] used, int index = 0)
    {
        if (index >= digits.Length)
        {
            CheckForResult(digitsCopy);
            return;
        }

        for (int i = 0; i < digits.Length; i++)
        {
            if (!used[i])
            {
                digitsCopy[index] = digits[i];
                used[i] = true;
                GeneratePermutations(digits, digitsCopy, used, index + 1);
                used[i] = false;
            }
        }
    }

    private static void CheckForResult(byte[] digits)
    {
        int currentNumber = MakeNumber(digits);
        int divisorsCount = GetDivisorsCount(currentNumber);
        if (divisorsCount < minDivisorsCount)
        {
            minDivisorsCount = divisorsCount;
            resultNumber = currentNumber;
        }
        else if (divisorsCount == minDivisorsCount &&
            currentNumber < resultNumber)
        {
            resultNumber = currentNumber;
        }
    }

    private static int MakeNumber(byte[] digits)
    {
        int number = 0;
        int power = 1;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            number += digits[i] * power;
            power *= 10;
        }

        return number;
    }

    private static int GetDivisorsCount(int number)
    {
        int divisorsCount = 0;
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                divisorsCount++;
            }
        }

        return divisorsCount;
    }
}