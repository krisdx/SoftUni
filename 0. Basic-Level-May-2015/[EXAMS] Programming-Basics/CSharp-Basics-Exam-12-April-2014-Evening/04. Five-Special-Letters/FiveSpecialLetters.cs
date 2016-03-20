using System;

class FiveSpecialLetters
{
    static void Main() //-k.d
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        string[] letters = { "a", "b", "c", "d", "e" };

        bool solutionFound = false;
        for (int l1 = 0; l1 < letters.Length; l1++)
        {
            for (int l2 = 0; l2 < letters.Length; l2++)
            {
                for (int l3 = 0; l3 < letters.Length; l3++)
                {
                    for (int l4 = 0; l4 < letters.Length; l4++)
                    {
                        for (int l5 = 0; l5 < letters.Length; l5++)
                        {
                            int weight = GetLettersValue(letters[l1], letters[l2], letters[l3], letters[l4], letters[l5]);

                            if (weight >= start && weight <= end)
                            {
                                Console.Write(letters[l1] + letters[l2] + letters[l3] + letters[l4] + letters[l5] + " ");
                                solutionFound = true;
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

    private static int GetLettersValue(string l1, string l2, string l3, string l4, string l5)
    {
        string[] currentLettes = { l1, l2, l3, l4, l5 };

        bool repeatingA = false;
        bool repeatingB = false;
        bool repeatingC = false;
        bool repeatingD = false;
        bool repeatingE = false;

        int sum = 0;
        int index = 1;
        for (int i = 0; i < currentLettes.Length; i++)
        {
            if (currentLettes[i] == "a" && repeatingA)
            {
                continue;
            }
            else if (currentLettes[i] == "b" && repeatingB)
            {
                continue;
            }
            else if (currentLettes[i] == "c" && repeatingC)
            {
                continue;
            }
            else if (currentLettes[i] == "d" && repeatingD)
            {
                continue;
            }
            else if (currentLettes[i] == "e" && repeatingE)
            {
                continue;
            }

            switch (currentLettes[i])
            {
                case "a": sum += index * 5; repeatingA = true; index++; break;
                case "b": sum += index * -12; repeatingB = true; index++; break;
                case "c": sum += index * 47; repeatingC = true; index++; break;
                case "d": sum += index * 7; repeatingD = true; index++; break;
                case "e": sum += index * -32; repeatingE = true; index++; break;
            }
        }
        return sum;
    }
}