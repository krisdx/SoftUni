using System;

class BullsАndCows
{
    static void Main()
    {
        int secretNumber = int.Parse(Console.ReadLine());
        int tergetBulls = int.Parse(Console.ReadLine());
        int targetCows = int.Parse(Console.ReadLine());

        bool solutionFound = false;
        for (int guess = 1111; guess <= 9999; guess++)
        {
            char[] guessNum = guess.ToString().ToCharArray();
            char[] secretNum = secretNumber.ToString().ToCharArray();

            if (guessNum[0] >= '1' && guessNum[1] >= '1' && guessNum[2] >= '1' && guessNum[3] >= '1')
            {
                int bulls = 0;
                int cows = 0;

                for (int index = 0; index < secretNum.Length; index++)
                {
                    if (secretNum[index] == guessNum[index])
                    {
                        bulls++;
                        secretNum[index] = '*';
                        guessNum[index] = '@';
                    }
                }

                for (int guessNumIndex = 0; guessNumIndex < guessNum.Length; guessNumIndex++)
                {
                    for (int secretNumIndex = 0; secretNumIndex < secretNum.Length; secretNumIndex++)
                    {
                        if (secretNum[secretNumIndex] == guessNum[guessNumIndex])
                        {
                            cows++;
                            secretNum[secretNumIndex] = '*';
                            guessNum[guessNumIndex] = '@';
                        }
                    }
                }

                if (cows == targetCows && bulls == tergetBulls)
                {
                    Console.Write(guess + " ");
                    solutionFound = true;
                }
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }
}