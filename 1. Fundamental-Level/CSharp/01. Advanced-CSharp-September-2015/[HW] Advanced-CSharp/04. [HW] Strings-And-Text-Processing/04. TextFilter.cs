using System;

// Write a program that takes a text and a string of banned words. All words included in the ban list should be replaced with asterisks "*", equal to the word's length. The entries in the ban list will be separated by a comma and space ", ".

// The ban list should be entered on the first input line and the text on the second input line.

class TextFilter
{
    static void Main()
    {
        string[] bannedWords = Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
        string inputText = Console.ReadLine();

        string outputText = inputText;
        for (int word = 0; word < bannedWords.Length; word++)
        {
            string currentBannedWord = bannedWords[word];

            outputText = outputText.Replace(currentBannedWord, new string('*', currentBannedWord.Length));
        }

        Console.WriteLine(new string('-', 50));
        Console.WriteLine(outputText);
    }
}