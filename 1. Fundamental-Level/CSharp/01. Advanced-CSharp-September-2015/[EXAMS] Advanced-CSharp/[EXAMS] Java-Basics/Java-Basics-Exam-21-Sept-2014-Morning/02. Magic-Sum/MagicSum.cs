using System;
using System.Collections.Generic;

class MagicSum
{
    static void Main()
    {
        int divisor = int.Parse(Console.ReadLine());

        List<int> numbers = new List<int>();
        string inputNum = Console.ReadLine();
        while (inputNum != "End")
        {
            numbers.Add(int.Parse(inputNum));
            inputNum = Console.ReadLine();
        }

        int biggestSum = 0;
        int firstNum = 0;
        int secondNum = 0;
        int thirdNum = 0;

        bool solutionFound = false;
        int currentBiggestSum = int.MinValue;
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                for (int k = j + 1; k < numbers.Count; k++)
                {
                    int num1 = numbers[i];
                    int num2 = numbers[j];
                    int num3 = numbers[k];
                    int currentSum = num1 + num2 + num3;

                    if (currentSum % divisor == 0 && currentSum > currentBiggestSum)
                    {
                        currentBiggestSum = currentSum;

                        biggestSum = currentBiggestSum;
                        firstNum = num1;
                        secondNum = num2;
                        thirdNum = num3;
                        solutionFound = true;
                    }
                }
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine("({0} + {1} + {2}) % {3} = 0", firstNum, secondNum, thirdNum, divisor);
        }
    }
}