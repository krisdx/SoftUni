using System;

// Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500), a floating-point b and a floating-point c and prints them in 4 virtual columns on the console. Each column should have a width of 10 characters. The number a should be printed in hexadecimal, left aligned; then the number a should be printed in binary form, padded with zeroes, then the number b should be printed with 2 digits after the decimal point, right aligned; the number c should be printed with 3 digits after the decimal point, left aligned. 

class FormattingNumbers
{
    static void Main()
    {
        Console.Write("Please enter an integer (between 0 and 500): ");
        int a = int.Parse(Console.ReadLine());
        while (a < 0 || a > 500)
        {
            Console.Write("Please enter an integer (between 0 and 500): ");
            a = int.Parse(Console.ReadLine());
        }
        string aInBinary = Convert.ToString(a, 2).PadLeft(10, '0');

        Console.Write("Enter a floating-point number: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Enter second floating-point number: ");
        float c = float.Parse(Console.ReadLine());

        Console.WriteLine("\n|{0, -10:X}|{1}|{2, 10:F2}|{3, -10:F3}|", a, aInBinary, b, c);
    }
}