using System;

// Write methods to calculate the minimum, maximum, average, sum and product of a given set of numbers. Overload the methods to work with numbers of type double and decimal.

// Note: Do not use LINQ.

class NumberCalculations
{
    static void Main()
    {
        string[] input = Console.ReadLine().Trim().Split();
        decimal[] numbers = new decimal[input.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = decimal.Parse(input[i]);
        }

        GetMinNumber(numbers);
        GetMaxNumber(numbers);
        GetAverage(numbers);
        GetSum(numbers);
        GetProduct(numbers);
    }

    private static void GetMinNumber(decimal[] numbers)
    {
        decimal minNumber = decimal.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < minNumber)
            {
                minNumber = numbers[i];
            }
        }

        Console.WriteLine("Min number: {0}", minNumber);
    }

    private static void GetMaxNumber(decimal[] numbers)
    {
        decimal maxNumber = decimal.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > maxNumber)
            {
                maxNumber = numbers[i];
            }
        }

        Console.WriteLine("Max number: {0}", maxNumber);
    }

    private static void GetAverage(decimal[] numbers)
    {
        decimal average = 0;
        decimal sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        average = sum / numbers.Length;
        Console.WriteLine("Average: {0}", average);
    }

    private static void GetSum(decimal[] numbers)
    {
        decimal sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        Console.WriteLine("Sum: {0}", sum);
    }

    private static void GetProduct(decimal[] numbers)
    {
        decimal product = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }

        Console.WriteLine("Product: {0}", product);
    }
}