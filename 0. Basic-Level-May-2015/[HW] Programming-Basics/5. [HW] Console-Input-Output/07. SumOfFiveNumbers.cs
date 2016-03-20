using System;
using System.Linq;

// Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.

class SumOfFiveNumbers
{
    static void Main()
    {
        Console.Write("Enter five numbers separated by space: ");

        string[] numbers = Console.ReadLine().Split(' '); 
        double[] convertingNumbers = new double[numbers.Length]; 
        
        for (int i = 0; i < numbers.Length; i++) 
        {
            convertingNumbers[i] = double.Parse(numbers[i]);
        }

        int sum = (int)convertingNumbers.Sum();

        Console.WriteLine("\nThe sum of the numbers is: {0}\n", sum);
    }
}