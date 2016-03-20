using System;

// Create a program that assigns null values to an integer and to a double variable. Try to print these variables at the console. Try to add some number or the null literal to these variables and print the result.

class NullValuesArithmetic
{
    static void Main()
    {
        int? variable1 = null;
        double? variable2 = null;

        Console.WriteLine("When we declare null values to type integer and double, they look like this: {0} {1}", variable1, variable2);

        variable1 += 13;
        variable2 += 0.19;
        Console.WriteLine("\nWhen we add {0} to the integer it looks like: {1}\n\nAnd adding {2} to double looks like this: {3}\n", 13, variable1, 0.19, variable2);
    }
}