using System;

class WeirdCombinations
{
    public static void Main() //-k.d
    {
        string input = Console.ReadLine();
        uint nthNumber = uint.Parse(Console.ReadLine());

        char[] sequence = input.ToCharArray();

        bool solutionFound = false;
        ulong counter = 0;
        for (int l1 = 0; l1 < sequence.Length; l1++)
        {
            for (int l2 = 0; l2 < sequence.Length; l2++)
            {
                for (int l3 = 0; l3 < sequence.Length; l3++)
                {
                    for (int l4 = 0; l4 < sequence.Length; l4++)
                    {
                        for (int l5 = 0; l5 < sequence.Length; l5++)
                        {
                            if (counter == nthNumber)
                            {
                                Console.WriteLine("{0}{1}{2}{3}{4}", sequence[l1], sequence[l2], sequence[l3], sequence[l4], sequence[l5]);
                                solutionFound = true;
                            }
                            counter++;
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