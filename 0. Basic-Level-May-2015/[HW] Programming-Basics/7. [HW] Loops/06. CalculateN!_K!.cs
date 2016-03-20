using System;

class Program
{
    static void Main()
    {
        Console.Write("Please, enter n! (1 < n < 100) = ");
        int n = int.Parse(Console.ReadLine());

        if (n < 1 || n > 100)
        {
            Console.WriteLine("Sorry, number out of range.");
        }
        else
        {
            Console.Write("Please, enter k! (1 < k < n < 100) = ");
            int k = int.Parse(Console.ReadLine());
            if (k < 1 || k > 100)
            {
                Console.WriteLine("Sorry, number out of range.");
            }
            else
            {
                int factorialN = 1;
                int factorialK = 1;

                while (n >= 1)
                {
                    factorialN *= n;
                    n--;
                }
                while (k > 1)
                {
                    factorialK *= k;
                    k--;
                }
                int nK = factorialN / factorialK;
                Console.WriteLine("\nResult: " + nK);
            }
        }
    }
}