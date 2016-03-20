using System;

// Write a method GetMax() with two parameters that returns the larger of two integers. Write a program that reads 2 integers from the console and prints the largest of them using the method GetMax().

class BiggerNumber
{
    static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());

        int biggestNum = GetBiggestNum(firstNum, secondNum);
        Console.WriteLine("The biggest number is: {0}", biggestNum);
    }

    private static int GetBiggestNum(int firstNum, int secondNum)
    {
        int biggestNum;

        if (firstNum > secondNum)
        {
            biggestNum = firstNum;
        }
        else
        {
            biggestNum = secondNum;
        }

        return biggestNum;
    }
}