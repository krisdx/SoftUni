using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

// Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file text.txt. Matching should be case-insensitive.

// Write the results in file results.txt. Sort the words by frequency in descending order. Use StreamReader in combination with StreamWriter

class WordCount
{
    static void Main()
    {
        Dictionary<string, int> wordAndCount = new Dictionary<string, int>();

        StreamReader wordsReader = new StreamReader("../../Words.txt");
        using (wordsReader)
        {
            while (true)
            {
                string word = wordsReader.ReadLine();
                if (word == null)
                {
                    break;
                }
                Regex regex = new Regex("\\b" + word, RegexOptions.IgnoreCase);

                StreamReader textReader = new StreamReader("../../Text.txt");
                using (textReader)
                {
                    while (true)
                    {
                        string sentence = textReader.ReadLine();
                        if (sentence == null)
                        {
                            break;
                        }
                        MatchCollection matchCollection = regex.Matches(sentence);

                        if (wordAndCount.ContainsKey(word))
                        {
                            wordAndCount[word] += matchCollection.Count;
                        }
                        else if (matchCollection.Count > 0)
                        {
                            wordAndCount.Add(word, matchCollection.Count);
                        }
                    }
                }
            }
        }

        foreach (var word in wordAndCount.OrderByDescending(x => x.Value))
        {
            Console.WriteLine("{0} - {1}", word.Key, word.Value);
        }
    }
}