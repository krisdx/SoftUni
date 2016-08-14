using System;
using System.Collections.Generic;
using System.Linq;

public class BinaryPasswords
{
    public static void Main()
    {
        string password = Console.ReadLine();
        int starsCount = password.Where(c => c == '*').Count();

        long result = GetPossibleCombinations(starsCount);
        Console.WriteLine(result);
    }

    private static long GetPossibleCombinations(int starsCount)
    {
        long result = 1;
        for (int i = 0; i < starsCount; i++)
        {
            result *= 2;
        }

        return result;
    }
}