using System;
using System.Diagnostics;

public class PerformanceOfOperations
{
    private const int N = 500;

    public static void Main()
    {
        decimal firstOperand = 500m;
        decimal secondOperand = 500m;

        decimal result = 500;

        Stopwatch timer = new Stopwatch();

        timer.Start();
        for (int i = 0; i < N; i++)
        {
           var a = Math.Sqrt((double)result);
        }
        timer.Stop();

        Console.WriteLine(timer.Elapsed);
    }
}