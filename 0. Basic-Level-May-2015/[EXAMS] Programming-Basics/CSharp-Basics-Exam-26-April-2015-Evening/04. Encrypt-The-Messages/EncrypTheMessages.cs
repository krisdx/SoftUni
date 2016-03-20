using System;
using System.Collections.Generic;

class EncrypTheMessages //-k.d
{
    static void Main()
    {
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (input == "START" || input == "start")
            {
                break;
            }
        }

        string inputMessage;
        bool hasRecievedAnyMessages = false;
        List<string> messages  = new List<string>();
        while (true)
        {
            inputMessage = Console.ReadLine();
            if (inputMessage =="END" || inputMessage == "end")
            {
                break;
            }
            if (inputMessage != "")
            {
                hasRecievedAnyMessages = true;
                messages.Add(inputMessage);
            }
        }

        if (!hasRecievedAnyMessages)
        {
            Console.WriteLine("No messages sent.");
            return;
        }

        Console.WriteLine("Total number of messages: {0}", messages.Count);

        for (int currentMessage = 0; currentMessage < messages.Count; currentMessage++)
        {
            char[] decryptedMessage = messages[currentMessage].ToCharArray();
            char[] encryptMessage = new char[decryptedMessage.Length];
            for (int currentChar = 0; currentChar < decryptedMessage.Length; currentChar++)
            {
                char encryptedChar = EncrypChar(decryptedMessage[currentChar]);
                encryptMessage[currentChar] = encryptedChar;
            }

            Array.Reverse(encryptMessage);
            foreach (char symbol in encryptMessage)
            {
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }

    private static char EncrypChar(char currentChar)
    {
        char encryptedChar = ' ';

        if (char.IsLetter(currentChar))
        {
            if (char.IsLower(currentChar))
            {
                if (currentChar >= 'a' && currentChar <= 'm')
                {
                    currentChar += (char)13;
                    encryptedChar = currentChar;
                }
                else
                {
                    currentChar -= (char)13;
                    encryptedChar = currentChar;
                }
            }
            else
            {
                if (currentChar >= 'A' && currentChar <= 'M')
                {
                    currentChar += (char)13;
                    encryptedChar = currentChar;
                }
                else
                {
                    currentChar -= (char)13;
                    encryptedChar = currentChar;
                }
            }
        }
        else if (char.IsDigit(currentChar))
        {
            encryptedChar = currentChar;
        }
        else
        {
            switch (currentChar)
            {
                case ' ': encryptedChar = '+'; break;
                case ',': encryptedChar = '%'; break;
                case '.': encryptedChar = '&'; break;
                case '?': encryptedChar = '#'; break;
                case '!': encryptedChar = '$'; break;
                default: encryptedChar = currentChar; break;
            }
        }

        return encryptedChar;
    }
}