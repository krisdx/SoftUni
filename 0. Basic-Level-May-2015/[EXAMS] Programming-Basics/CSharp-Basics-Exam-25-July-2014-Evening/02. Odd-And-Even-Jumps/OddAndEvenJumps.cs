using System;

class OddAndEvenJumps //-k.d
{
    static void Main()
    {
        string input = Console.ReadLine();
        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());

        char[] letters = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            letters[i] = input[i];
            letters[i] = char.ToLower(letters[i]);
        }

        ulong oddResult = 0;
        int oddCounter = 1;
        ulong evenResult = 0;
        int evenCounter = 1;
        int oddEvenLettersCounter = 1;
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] == ' ')
            {
                continue;
            }
            if (oddEvenLettersCounter % 2 == 1)
            {
                if (oddCounter == oddJump)
                {
                    oddResult *= letters[i];
                    oddCounter = 0;
                }
                else
                {
                    oddResult += letters[i];
                }
                oddCounter++;
                oddEvenLettersCounter++;
            }
            else
            {
                if (evenCounter == evenJump)
                {
                    evenResult *= letters[i];
                    evenCounter = 0;
                }
                else
                {
                    evenResult += letters[i];
                }
                evenCounter++;
                oddEvenLettersCounter++;
            }
        }

        Console.WriteLine("Odd: {0:X}", oddResult);
        Console.WriteLine("Even: {0:X}", evenResult);
    }
}