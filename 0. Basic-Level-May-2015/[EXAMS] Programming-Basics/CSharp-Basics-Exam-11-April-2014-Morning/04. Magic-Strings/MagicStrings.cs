using System;

class MagicStrings
{
    static void Main() //-k.d
    {
        int diff = int.Parse(Console.ReadLine());

        string[] letters = { "k", "n", "p", "s" }; // alphabet order

        bool solutionFound = false;
        foreach (string letter1 in letters)
        {
            foreach (string letter2 in letters)
            {
                foreach (string letter3 in letters)
                {
                    foreach (string letter4 in letters)
                    {
                        foreach (string letter5 in letters)
                        {
                            foreach (string letter6 in letters)
                            {
                                foreach (string letter7 in letters)
                                {
                                    foreach (string letter8 in letters)
                                    {
                                        int firstSequence = GetLetterValue(letter1, letter2, letter3, letter4);
                                        int secondSeqeunce = GetLetterValue(letter5, letter6, letter7, letter8);

                                        if ((Math.Abs(firstSequence - secondSeqeunce) == diff))
                                        {
                                            Console.WriteLine(letter1 + letter2 + letter3 + letter4 + letter5 + letter6 + letter7 + letter8);
                                            solutionFound = true;
                                        }
                                    }
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

    private static int GetLetterValue(string letter1, string letter2, string letter3, string letter4)
    {
        string[] currentLetters = { letter1, letter2, letter3, letter4 };

        int sum = 0;
        for (int i = 0; i < currentLetters.Length; i++)
        {
            switch (currentLetters[i])
            {
                case "s": sum += 3;
                    break;
                case "n": sum += 4;
                    break;
                case "k": sum += 1;
                    break;
                case "p": sum += 5;
                    break;
            }
        }
        return sum;
    }
}