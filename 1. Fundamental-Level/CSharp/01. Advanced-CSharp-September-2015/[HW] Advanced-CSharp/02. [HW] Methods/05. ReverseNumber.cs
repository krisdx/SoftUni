using System;
using System.Linq;

// Write a method that reverses the digits of a given floating-point number.

class ReverseNumber
{
    static void Main()
    {
        string num = Console.ReadLine();

        double reversedNum = ReverseNum(num);
        Console.WriteLine("Reversed: {0}", reversedNum);
    }

    private static double ReverseNum(string num)
    {
        string reversedString = string.Join("", num.ToString().Reverse());
        double reversedNum = double.Parse(reversedString);

        return reversedNum;
    }
}