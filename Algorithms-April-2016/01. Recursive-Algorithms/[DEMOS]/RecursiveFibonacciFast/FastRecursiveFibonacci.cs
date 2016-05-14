namespace RecursiveFibonacciFast
{
    using System;

    public class FastRecursiveFibonacci
    {
        private const int MaxFibonacciSequenceMember = 1000;
        static decimal[] fibonacciNumbers = new decimal[MaxFibonacciSequenceMember];

        static decimal recursiveCallsCounter = 0;

        public static void Main()
        {
            int n = 100;
            decimal result = Fibonacci(n);
            Console.WriteLine("Fib({0}) = {1}", n, result);
            Console.WriteLine("Recursive calls = {0}", recursiveCallsCounter);
        }

        static decimal Fibonacci(int n)
        {
            recursiveCallsCounter++;
            if (fibonacciNumbers[n] == 0)
            {
                // The value of fibonacciNumbers[n] is still not calculated -> calculate it now
                if (n == 1 || n == 2)
                {
                    fibonacciNumbers[n] = 1;
                }
                else
                {
                    fibonacciNumbers[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
                }
            }

            return fibonacciNumbers[n];
        }
    }
}