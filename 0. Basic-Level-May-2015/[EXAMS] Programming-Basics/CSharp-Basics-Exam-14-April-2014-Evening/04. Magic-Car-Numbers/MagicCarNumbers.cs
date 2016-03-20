using System;

class MagicCarNumbers
{
    static void Main() //-k.d
    {
        int magicWeight = int.Parse(Console.ReadLine());

        char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };

        int matchingCarNumbers = 0;
        for (int digit1 = 1; digit1 <= 9; digit1++)
        {
            for (int digit2 = 1; digit2 <= 9; digit2++)
            {
                for (int letter1 = 0; letter1 < letters.Length; letter1++)
                {
                    for (int letter2 = 0; letter2 < letters.Length; letter2++)
                    {
                        int currentLettersWeigth = GetWeigth(letters[letter1], letters[letter2]);
                        if (currentLettersWeigth + (4 * digit1) == matchingCarNumbers || currentLettersWeigth + ((2 * digit1) + (2 * digit2))  == matchingCarNumbers)
                        {
                            matchingCarNumbers++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(matchingCarNumbers);
    }

    static int GetWeigth(char l1, char l2)
    {
       // int[] currentNumbers = { a, b };
        char[] currentLetters = { 'C', 'A', l1, l2 };

        int currentWeigth = 0;
        //for (int num = 0; num < currentNumbers.Length; num++)
        //{
        //    currentWeigth += currentNumbers[num];
        //}
        for (int letter = 0; letter < currentLetters.Length; letter++)
        {
            switch (currentLetters[letter])
            {
                case 'A': currentWeigth += 10; break;
                case 'B': currentWeigth += 20; break;
                case 'C': currentWeigth += 30; break;
                case 'E': currentWeigth += 50; break;
                case 'H': currentWeigth += 80; break;
                case 'K': currentWeigth += 110; break;
                case 'M': currentWeigth += 130; break;
                case 'P': currentWeigth += 160; break;
                case 'T': currentWeigth += 200; break;
                case 'X': currentWeigth += 240; break;
            }
        }

        return currentWeigth;
    }
}