using System;

// There are infinite number of triplets of integers a, b and c (a ≤ b), such that a2 + b2 = c2. Write a program that finds all such triplets (called Pythagorean numbers) among a set of integer numbers.

class PythagoreanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        bool solutionFound = false;
        for (int a = 0; a < n; a++)
        {
            for (int b = 0; b < n; b++)
            {
                for (int c = 0; c < n; c++)
                {
                    bool isBBiggerThanA = numbers[a] <= numbers[b];
                    bool isPythagoreanNumber =
                        (numbers[a] * numbers[a]) +
                        (numbers[b] * numbers[b]) ==
                        (numbers[c] * numbers[c]);

                    if (isPythagoreanNumber && isBBiggerThanA)
                    {
                        Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", numbers[a], numbers[b], numbers[c]);
                        solutionFound = true;
                    }
                }
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }
}