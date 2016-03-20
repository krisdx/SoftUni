using System;

class DetectiveBoev
{
    static void Main()
    {
        string secretWord = Console.ReadLine();
        string encryptedMessage = Console.ReadLine();

        int digitsSum = 0;
        for (int i = 0; i < secretWord.Length; i++)
        {
            digitsSum += secretWord[i];
        }

        int mask = digitsSum;
        while (mask > 10)
        {
            mask = SumDigits(mask);
        }

        char[] encryptedMessageArray = encryptedMessage.ToCharArray();
        for (int i = 0; i < encryptedMessageArray.Length; i++)
        {
            if (encryptedMessageArray[i] % mask == 0)
            {
                encryptedMessageArray[i] += (char)mask;
            }
            else
            {
                encryptedMessageArray[i] -= (char)mask;
            }
        }

        Array.Reverse(encryptedMessageArray);
        foreach (char ch in encryptedMessageArray)
        {
            Console.Write(ch);
        }
    }

    private static int SumDigits(int sumDigits)
    {
        int mask = 0;

        while (sumDigits > 0)
        {
            int lastDigit = sumDigits % 10;
            mask += lastDigit;
            sumDigits /= 10;
        }

        return mask;
    }
}