using System;

class ThreeLargestNumbers
{
    static decimal firstLargestNum = decimal.MinValue;
    static decimal secondLargestNum = decimal.MinValue;
    static decimal thirdLargestNum = decimal.MinValue;

    static void Main() // Java needed
    {
        int n = int.Parse(Console.ReadLine());

        decimal[] numbers = new decimal[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = decimal.Parse(Console.ReadLine());
        }

        GetLargestNum(numbers);
        if (numbers.Length == 1)
        {
            Console.WriteLine(firstLargestNum);
        }
        else if (numbers.Length == 2)
        {
            GetSecondLargestNum(numbers);
            Console.WriteLine(firstLargestNum);
            Console.WriteLine(secondLargestNum);
        }
        else if (numbers.Length >= 3)
        {
            GetSecondLargestNum(numbers);
            GetTrirdLargestNum(numbers);
            Console.WriteLine(firstLargestNum);
            Console.WriteLine(secondLargestNum);
            Console.WriteLine(thirdLargestNum);
        }
    }

    static void GetLargestNum(decimal[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > firstLargestNum)
            {
                firstLargestNum = numbers[i];
            }
        }
    }

    static void GetSecondLargestNum(decimal[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > secondLargestNum && numbers[i] < firstLargestNum)
            {
                secondLargestNum = numbers[i];
            }
        }
    }

    static void GetTrirdLargestNum(decimal[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > thirdLargestNum && numbers[i] < firstLargestNum && numbers[i] < secondLargestNum)
            {
                thirdLargestNum = numbers[i];
            }
        }
    }
}