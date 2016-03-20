using System;
using System.Collections.Generic;
using System.Text;

class WeirdStrings
{
    static void Main()
    {
        string input = RemoveJunkCharacters(Console.ReadLine());

        List<string> words = GetWords(input);

        int maxWeigth = int.MinValue;
        string biggestWord1 = string.Empty;
        string biggestWord2 = string.Empty;
        for (int i = 0; i < words.Count - 1; i++)
        {
            int firstWordWeight = GetWordWeight(words[i]);
            int secondWordWeigth = GetWordWeight(words[i + 1]);

            int currentWeigth = firstWordWeight + secondWordWeigth;
            if (currentWeigth >= maxWeigth)
            {
                maxWeigth = currentWeigth;
                biggestWord1 = words[i];
                biggestWord2 = words[i + 1];
            }
        }

        Console.WriteLine("{0}\n{1}", biggestWord1, biggestWord2);
    }

    static List<string> GetWords(string input)
    {
        List<string> words = new List<string>();
        StringBuilder word = new StringBuilder();

        int counter = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetter(input[i]))
            {
                counter++;
                word.Append(input[i]);
            }
            else
            {
                if (counter > 1)
                {
                    words.Add(word.ToString());
                }

                word.Clear();
                counter = 0;
            }
        }

        if (counter > 1)
        {
            words.Add(word.ToString());
        }

        return words;
    }

    static string RemoveJunkCharacters(string input)
    {
        List<char> junkChars = new List<char> { '\\', '/', '(', ')', '|', ' ' };

        StringBuilder cleanedInput = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (!junkChars.Contains(input[i]))
            {
                cleanedInput.Append(input[i]);
            }
        }

        return cleanedInput.ToString();
    }

    static int GetWordWeight(string word)
    {
        int wordWeigth = 0;
        for (int i = 0; i < word.Length; i++)
        {
            if (char.IsUpper(word[i]))
            {
                wordWeigth += (word[i] - 'A') + 1;
            }
            else
            {
                wordWeigth += (word[i] - 'a') + 1;
            }
        }

        return wordWeigth;
    }
}