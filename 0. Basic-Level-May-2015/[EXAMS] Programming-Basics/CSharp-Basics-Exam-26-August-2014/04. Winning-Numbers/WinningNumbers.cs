using System;

class WinningNumbers //-k.d
{
    static void Main()
    {
        string input = Console.ReadLine();

        char[] letters = new char[input.Length];
        int lettersSum = 0;
        for (int i = 0; i < letters.Length; i++)
        {
            char currnetChar = input[i];
            currnetChar = char.ToLower(currnetChar);
            if (char.IsLetter(currnetChar))
            {
                lettersSum += currnetChar - ('a' - 1);
            }
        }

        bool solutionFound = false;
        for (int l1 = 0; l1 <= 9; l1++)
        {
            for (int l2 = 0; l2 <= 9; l2++)
            {
                for (int l3 = 0; l3 <= 9; l3++)
                {
                    for (int l4 = 0; l4 <= 9; l4++)
                    {
                        for (int l5 = 0; l5 <= 9; l5++)
                        {
                            for (int l6 = 0; l6 <= 9; l6++)
                            {
                                int firstTriple = (l1 * l2 * l3);
                                int secondTriple = (l4 * l5 * l6);
                                if (firstTriple == lettersSum && secondTriple == lettersSum)
                                {
                                    Console.WriteLine("{0}{1}{2}-{3}{4}{5}", l1, l2, l3, l4, l5, l6);
                                    solutionFound = true;
                                }
                            }
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