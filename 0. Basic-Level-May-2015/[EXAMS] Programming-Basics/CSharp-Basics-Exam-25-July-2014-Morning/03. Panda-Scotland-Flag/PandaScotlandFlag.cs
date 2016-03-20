using System;

class PandaScotlandFlag //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n == 1)
        {
            Console.Write('A');
        }
        else
        {
            char letter = 'A';

            int hashTagsCounter = n - 2;
            string hashTags = new string('#', hashTagsCounter);
            int tildeCounter = 1;
            string tilde = new string('~', tildeCounter);

            Console.WriteLine(letter + hashTags + GetNextLetter(letter));
            letter = GetNextLetter(letter);
            hashTagsCounter -= 2;

            for (int i = 0; i < n / 2 - 1; i++)
            {
                hashTags = new string('#', hashTagsCounter);
                if (n == 3)
                {
                    tildeCounter = 0;
                }
                tilde = new string('~', tildeCounter);
                Console.Write(tilde);
                letter = GetNextLetter(letter);
                Console.Write(letter);
                Console.Write(hashTags);
                letter = GetNextLetter(letter);
                Console.Write(letter);
                Console.WriteLine(tilde);
                hashTagsCounter -= 2;
                tildeCounter++;
            }
            letter = GetNextLetter(letter);
            Console.WriteLine(new string('-', n / 2) + letter + new string('-', n / 2));

            tildeCounter = (n - 3) / 2;
            hashTagsCounter = 1;
            for (int i = 0; i < n / 2 - 1; i++)
            {
                hashTags = new string('#', hashTagsCounter);
                tilde = new string('~', tildeCounter);
                Console.Write(tilde);
                letter = GetNextLetter(letter);
                Console.Write(letter);
                Console.Write(hashTags);
                letter = GetNextLetter(letter);
                Console.Write(letter);
                Console.WriteLine(tilde);
                tildeCounter--;
                hashTagsCounter += 2;
            }
            letter = GetNextLetter(letter);
            Console.Write(letter);
            Console.Write(new string('#', n - 2));
            letter = GetNextLetter(letter);
            Console.Write(letter);
        }
    }

    static char GetNextLetter(char currentChar)
    {
        currentChar++;
        if (currentChar > 'Z')
        {
            currentChar = 'A';
        }
        return currentChar;
    }
}