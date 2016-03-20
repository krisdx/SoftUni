using System;
using System.Collections.Generic;

class DecryptTheMessages //-k.d
{
    static void Main()
    {
        // messages before "start"
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (input == "START" || input == "start")
            {
                break;
            }
        }

        List<string> messages = new List<string>();
        string inputMessage;
        bool recievedAnyMessages = false;
        while (true)
        {
            inputMessage = Console.ReadLine();
            if (inputMessage == "END" || inputMessage == "end")
            {
                break;
            }
            if (inputMessage != "")
            {
                recievedAnyMessages = true;
                messages.Add(inputMessage);
            }
        }

        if (!recievedAnyMessages)
        {
            Console.WriteLine("No message received.");
            return;
        }

        Console.WriteLine("Total number of messages: {0}", messages.Count);

        for (int message = 0; message < messages.Count; message++)
        {
            char[] currentMessage = messages[message].ToCharArray();
            char[] decryptedMessage = new char[currentMessage.Length];
            for (int currentChar = 0; currentChar < currentMessage.Length; currentChar++)
            {
                char decryptedChar = GetDecryptChar(currentMessage[currentChar]);
                decryptedMessage[currentChar] = decryptedChar;
            }

            Array.Reverse(decryptedMessage);
            foreach (char symbol in decryptedMessage)
            {
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }

    private static char GetDecryptChar(char currentChar)
    {
        char decryptedChar = ' ';

        if (char.IsLetter(currentChar))
        {
            if (char.IsLower(currentChar))
            {
                if (currentChar >= 'a' && currentChar <= 'm')
                {
                    currentChar += (char)13;
                    decryptedChar = currentChar;
                }
                else //if (currentChar >= 'm' && currentChar <= 'z')
                {
                    currentChar -= (char)13;
                    decryptedChar = currentChar;
                }
            }
            else
            {
                if (currentChar >= 'A' && currentChar <= 'M')
                {
                    currentChar += (char)13;
                    decryptedChar = currentChar;
                }
                else //if (currentChar >= 'M' && currentChar <= 'Z')
                {
                    currentChar -= (char)13;
                    decryptedChar = currentChar;
                }
            }
        }
        else if (char.IsDigit(currentChar))
        {
            decryptedChar = currentChar;
        }
        else //if currentChar is symbol
        {
            switch (currentChar)
            {
                case '+': decryptedChar = ' '; break;
                case '%': decryptedChar = ','; break;
                case '&': decryptedChar = '.'; break;
                case '#': decryptedChar = '?'; break;
                case '$': decryptedChar = '!'; break;
                default: decryptedChar = currentChar; break;
            }
        }
        return decryptedChar;
    }
}