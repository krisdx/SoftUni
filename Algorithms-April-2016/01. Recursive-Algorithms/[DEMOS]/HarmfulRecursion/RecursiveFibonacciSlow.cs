namespace HarmfulRecursion
{
    using System;

    public class RecursiveFibonacciSlow
    {
        public static void Main()
        {
            Console.Write("Fib(10) = ");
            decimal fib10 = Fibonacci(10);
            Console.WriteLine(fib10);

            Console.Write("Fib(50) = ");
            decimal fib50 = Fibonacci(50);
            Console.WriteLine(fib50);
        }

        static decimal Fibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}