using System;

// Write a program that reads 3 real numbers from the console and prints their sum.

class SumOfThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Please enter 3 real numbers: \n");

        Console.Write("Please enter a = ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("Please enter a = ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.Write("Please enter a = ");
        double thirdNumber = double.Parse(Console.ReadLine());

        double sum = (firstNumber + secondNumber + thirdNumber);

        Console.WriteLine("\nThe sum is: {0}\n", sum);
    }
}