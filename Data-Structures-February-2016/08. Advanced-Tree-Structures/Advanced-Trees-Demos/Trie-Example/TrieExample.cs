using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class TrieExample
{
    private const string VocabularyPath = "vocabulary.txt";

    public static void Main()
    {

        var words = LoadWords(VocabularyPath);
        Console.WriteLine("Words count: {0}", words.Count());

        const int PrefixLength = 2;
        var prefixes = GetAllMatches(Enumerable.Range('A', 'Z' - 'A' + 1).
            Select(i => ((char)i)).ToArray(), PrefixLength)
            .ToArray();
        Console.WriteLine("Search prefixes count: {0}", prefixes.Count());
        Console.WriteLine();

        var stopWatch = Stopwatch.StartNew();
        int matchesCount = 0;
        foreach (var prefix in prefixes)
        {
            var resultArray = words.Where(w => w.StartsWith(prefix)).ToArray();
            matchesCount += resultArray.Count();
        }
        Console.WriteLine("Found {0} matches", matchesCount);
        stopWatch.Stop();
        Console.WriteLine("Regular string matching time: {0} ms",
            stopWatch.ElapsedMilliseconds);
        Console.WriteLine();

        stopWatch.Restart();
        var trie = new Trie<bool>();
        trie.AddRange(words.Select(w => new TrieEntry<bool>(w, false)));
        stopWatch.Stop();
        Console.WriteLine("Build trie time: {0} ms", stopWatch.ElapsedMilliseconds);
        Console.WriteLine();

        stopWatch.Restart();
        matchesCount = 0;
        foreach (var prefix in prefixes)
        {
            var resultTrie = trie.GetByPrefix(prefix).Select(w => w.Key).ToArray();
            matchesCount += resultTrie.Count();
        }
        Console.WriteLine("Found {0} matches", matchesCount);
        stopWatch.Stop();
        Console.WriteLine("Trie find prefixes time: {0} ms", stopWatch.ElapsedMilliseconds);
    }

    private static IEnumerable<string> GetAllMatches(char[] chars, int length)
    {
        var indexes = new int[length];
        var current = new char[length];

        for (int i = 0; i < length; i++)
        {
            current[i] = chars[0];
        }

        do
        {
            yield return new string(current);
        }
        while (Increment(indexes, current, chars));
    }

    private static bool Increment(int[] indexes, char[] current, char[] chars)
    {
        int position = indexes.Length - 1;

        while (position >= 0)
        {
            indexes[position]++;
            if (indexes[position] < chars.Length)
            {
                current[position] = chars[indexes[position]];
                return true;
            }

            indexes[position] = 0;
            current[position] = chars[0];
            position--;
        }

        return false;
    }

    /// <summary>
    /// Returns distinct set of words. <remarks>This method returns 58110 English words.</remarks>
    /// </summary>
    /// <returns>Distinct set of words.</returns>
    private static IEnumerable<string> LoadWords(string fileName)
    {
        var path = Path.Combine(@"..\..\", fileName);
        return File.ReadAllLines(path);
    }
}
