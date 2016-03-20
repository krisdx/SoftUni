using System;

class FourFactors
{
    static void Main()
    {
        decimal FG = decimal.Parse(Console.ReadLine());
        decimal FGA = decimal.Parse(Console.ReadLine());
        decimal threeP = decimal.Parse(Console.ReadLine());
        decimal TOV = decimal.Parse(Console.ReadLine());
        decimal ORB = decimal.Parse(Console.ReadLine());
        decimal OppDRB = decimal.Parse(Console.ReadLine());
        decimal FT = decimal.Parse(Console.ReadLine());
        decimal FTA = decimal.Parse(Console.ReadLine());

        decimal eFG = (FG + 0.5m * threeP) / FGA;
        decimal TOVResult = TOV / (FGA + 0.44m * FTA + TOV);
        decimal ORBResult = ORB / (ORB + OppDRB);//
        decimal FTResult = FT / FGA;

        Console.WriteLine("eFG% {0:F3}", eFG);
        Console.WriteLine("TOV% {0:F3}", TOVResult);
        Console.WriteLine("ORB% {0:F3}", ORBResult);
        Console.WriteLine("FT% {0:F3}", FTResult);
    }
}