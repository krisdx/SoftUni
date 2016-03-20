using System;

public class ReverseWordsInAString
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split();

        string[] wordsInReverseOrder = new string[words.Length];

        int reverseCounter = words.Length - 1;
        for (int i = 0; i < words.Length; i++)
        {
            wordsInReverseOrder[i] = words[reverseCounter].ToLower();
            reverseCounter--;
        }
        
        Console.WriteLine(string.Join(" ", wordsInReverseOrder));
    }
}