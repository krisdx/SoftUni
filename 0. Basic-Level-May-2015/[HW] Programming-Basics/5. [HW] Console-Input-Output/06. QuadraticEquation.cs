using System;

// Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Please enter: ");

        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        double discriminant = Math.Pow(b, 2) - (4 * a * c);

        double x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        double x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

        Console.WriteLine("\nx1 = {0}; x2 = {1}", x1, x2);
    }
}