using System;
using System.Collections.Generic;

class BePositiveMain
{
    static void Main()
    {
        int seuqencesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < seuqencesCount; i++)
        {
            string[] inputSequence = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<int> numbers = new List<int>();
            for (int j = 0; j < inputSequence.Length; j++)
            {
                if (!inputSequence[j].Equals(string.Empty))
                {
                    int num = int.Parse(inputSequence[j]);
                    numbers.Add(num);
                }
            }

            bool solutionFound = false;
            for (int index = 0; index < numbers.Count; index++)
            {
                int currentNum = numbers[index];

                if (currentNum >= 0)
                {
                    if (solutionFound)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(currentNum);

                    solutionFound = true;
                }
                else
                {
                    if (index == numbers.Count - 1)
                    {
                        continue;
                    }

                    currentNum += numbers[index + 1];
                    if (currentNum >= 0)
                    {
                        if (solutionFound)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(currentNum);

                        solutionFound = true;
                    }

                    index++;
                }
            }
            
            if (!solutionFound)
            {
                Console.WriteLine("(empty)");
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}