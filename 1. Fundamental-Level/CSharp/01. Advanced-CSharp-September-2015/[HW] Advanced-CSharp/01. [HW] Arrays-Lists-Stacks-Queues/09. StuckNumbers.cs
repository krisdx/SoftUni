using System;

class StuckNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] numbers = Console.ReadLine().Split();

        bool solutionFound = false;
        for (int a = 0; a < n; a++)
        {
            for (int b = 0; b < n; b++)
            {
                for (int c = 0; c < n; c++)
                {
                    for (int d = 0; d < n; d++)
                    {
                        string leftSequence = numbers[a] + numbers[b];
                        string rightSequence = numbers[c] + numbers[d];

                        bool areDifferent =
                        (a != b && a != c && a != d) &&
                        (b != a && b != c && b != d) &&
                        (c != a && c != b && c != d) &&
                        (d != a && d != b && d != c);

                        if (leftSequence == rightSequence && areDifferent)
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", numbers[a], numbers[b], numbers[c], numbers[d]);
                            solutionFound = true;
                        }
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