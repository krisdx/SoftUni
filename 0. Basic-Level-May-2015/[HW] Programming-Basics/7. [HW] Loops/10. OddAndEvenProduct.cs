using System;

// You are given n integers (given in a single line, separated by a space). Write a program that checks whether the product of the odd elements is equal to the product of the even elements. Elements are counted from 1 to n, so the first element is odd, the second is even, etc. 

class OddAndEvenProduct
{
    static void Main()
    {
        Console.WriteLine("Please, entre some integers, separeted by space:");
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        int[] numbersInt = new Int32[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbersInt[i] = int.Parse(numbers[i]);
        }

        int productOdd = 1;
        int productEven = 1;

        for (int i = 1; i <= numbersInt.Length; i = i + 2)
        {
            productOdd *= numbersInt[i - 1];
        }
       
        for (int i = 1; i < numbersInt.Length; i = i + 2)
        {
            productEven *= numbersInt[i];
        }

        if (productEven == productOdd)
        {
            Console.WriteLine("\nYes, product {0}\n", productEven);
        }
        else
        {
            Console.WriteLine("\nNo.");
            Console.WriteLine("Odd_product = {0}", productOdd);
            Console.WriteLine("Even_product = {0}\n", productEven);
        }
    }
}