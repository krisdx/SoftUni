using System;
using System.Linq;

class Enigma
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string encryptedMessage = Console.ReadLine();
            int length = GetLength(encryptedMessage);
            char[] decryptedMessage = DecryptMessage(encryptedMessage, length);
            Console.WriteLine(string.Join("", decryptedMessage));
        }
    }

    static char[] DecryptMessage(string encryptedMessage, int length)
    {
        char[] decryptedMessage = encryptedMessage.ToCharArray();

        for (int i = 0; i < decryptedMessage.Length; i++)
        {
            if (!char.IsDigit(encryptedMessage[i]) && !char.IsWhiteSpace(encryptedMessage[i]))
            {
                decryptedMessage[i] = (char)(decryptedMessage[i] + length);
            }
        }

        return decryptedMessage;
    }

    static int GetLength(string encryptedMessage)
    {
        int length = 0;
        for (int i = 0; i < encryptedMessage.Length; i++)
        {
            if (!char.IsDigit(encryptedMessage[i]) && !char.IsWhiteSpace(encryptedMessage[i]))
            {
                length++;
            }
        }

        return length / 2;
    }
}