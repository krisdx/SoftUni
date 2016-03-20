using System;

public class ImpressTheGirlfriend
{
    public static void Main()
    {
        long[] gamePrices = new long[5];
        gamePrices[0] = (long)Math.Ceiling((uint.Parse(Console.ReadLine()) / 100) * 3.5);
        gamePrices[1] = (long)Math.Ceiling(uint.Parse(Console.ReadLine()) * 1.5);
        gamePrices[2] = (long)Math.Ceiling(uint.Parse(Console.ReadLine()) * 1.95);
        gamePrices[3] = (long)Math.Ceiling((uint.Parse(Console.ReadLine()) / 2m));
        gamePrices[4] = uint.Parse(Console.ReadLine());

        long mostExpensiveGame = long.MinValue;
        for (int i = 0; i < gamePrices.Length; i++)
        {
            if (mostExpensiveGame < gamePrices[i])
            {
                mostExpensiveGame = gamePrices[i];
            }
        }

        Console.WriteLine("{0:F2}", mostExpensiveGame);
    }
}
