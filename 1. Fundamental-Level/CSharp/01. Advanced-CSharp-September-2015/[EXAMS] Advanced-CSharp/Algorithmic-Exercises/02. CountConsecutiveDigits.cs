using System;
using System.Text;

public class CountConsecutiveDigits
{
    static void Main()
    {
        string inputNum = Console.ReadLine();

        StringBuilder result = new StringBuilder();
        int equalCounter = 2;
        for (int i = 0; i < inputNum.Length - 1; i++)
        {
            char currentNum = inputNum[i];
            char nextNum = inputNum[i + 1];

            if (currentNum == nextNum)
            {
                equalCounter = 2;
                while (i < inputNum.Length - 2)
                {
                    i++;
                    if (inputNum[i] != inputNum[i + 1])
                    {
                        break;
                    }

                    equalCounter++;
                }

                result.Append(equalCounter.ToString() + currentNum);
                equalCounter = 0;
            }
            else
            {
                result.Append("1" + currentNum);
            }
        }

        if (equalCounter != 0)
        {
            result.Append("1" + inputNum[inputNum.Length - 1]);
        }

        Console.WriteLine(result);
    }
}