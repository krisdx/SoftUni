using System;

public class InterestCalculatorMain
{
    private const int N = 12;

    public static void Main()
    {
        var compoundInterest = new InterestCalculator(500d, 5.6, 10, CalcualteCompoundInterest);
        Console.WriteLine(compoundInterest);

        var simpleinterest = new InterestCalculator(2500d, 7.2, 15, CalculateSimpleInterest);
        Console.WriteLine(simpleinterest);
    }

    private static double CalculateSimpleInterest(double sum, double interest, int years)
    {
        return sum * (1 + (interest / 100) * years);
    }

    private static double CalcualteCompoundInterest(double sum, double interest, int years)
    {
        return sum * Math.Pow((1 + (interest / 100) / N), N * years);
    }
}