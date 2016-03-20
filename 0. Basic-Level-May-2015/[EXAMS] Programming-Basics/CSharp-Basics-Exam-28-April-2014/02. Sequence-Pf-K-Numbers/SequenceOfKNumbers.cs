using System;

class SequenceOfKNumbers
{
    static void Main()
    {
        string inputLine = Console.ReadLine() + " " + int.MaxValue; // !!! int.MaxValue
        int k = int.Parse(Console.ReadLine());

        string[] numbers = inputLine.Split(' '); // no need for int[]

        string previousNum = numbers[0];
        int equalCounter = 1;
        for (int i = 1; i < numbers.Length; i++)
        {
            string currentNum = numbers[i];

            if (previousNum == currentNum)
            {
                equalCounter++;
            }
            else
            {
                for (int j = 0; j < equalCounter % k; j++)
                {
                    Console.Write(previousNum + " ");
                }

                equalCounter = 1;
            }

            previousNum = currentNum; 
        }
    }
}