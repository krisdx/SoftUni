using System;

// Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001. Note that we cannot directly compare two floating-point numbers a and b by a==b because of the nature of the floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant eps. 

class ComparingFloats
{
    static void Main()
    {
        Console.WriteLine("Please enter two floating type numbers for comparsion.");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine();

        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine();

        if (Math.Abs(a - b) < 0.000001)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}