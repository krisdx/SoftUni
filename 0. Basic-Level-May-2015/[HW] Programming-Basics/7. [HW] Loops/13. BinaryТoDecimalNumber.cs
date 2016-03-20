using System;

// Using loops write a program that converts a binary integer number to its decimal form. The input is entered as string. The output should be a variable of type long. Do not use the built-in .NET functionality.

class BinaryТoDecimalNumber
{
    static void Main()
    {
        Console.Write("Please, enter a number in binary digits: ");
        string inputBinary = Console.ReadLine();

        long[] binaryArray = new long[inputBinary.Length];
        int n = 0;

        for (int i = 0; i < binaryArray.Length; i++) // Converting to int.
        {
            binaryArray[i] = Convert.ToInt32(Convert.ToString(inputBinary[i]));
            n++; //  for Math.Pow
        }

        long result = 0;
        for (int i = 0; i < binaryArray.Length; i++)
        {
            if (binaryArray[i] != 0)
            {
                result += binaryArray[i] * (long)Math.Pow(2, (n - i - 1));
            }
        }
        Console.WriteLine("\nDecimal result : {0}\n", result);
    }
}