namespace Blocks
{
    using System;
    using System.Collections.Generic;

    public class Blocks
    {
        private static HashSet<string> usedCombinations = new HashSet<string>();

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var result = FindBlocks(n);
            PrintBlocks(result);
        }

        public static HashSet<string> FindBlocks(int numberOfLetters)
        {
            var letters = new char[numberOfLetters];
            FillLetters(numberOfLetters, letters);

            bool[] used = new bool[numberOfLetters];
            char[] currentCombination = new char[4];
            HashSet<string> results = new HashSet<string>();

            GenerateVariations(letters, currentCombination, used, results);

            return results;
        }

        private static void FillLetters(int numberOfLetters, char[] letters)
        {
            for (int i = 0; i < numberOfLetters; i++)
            {
                letters[i] = (char)('A' + i);
            }
        }

        private static void GenerateVariations(char[] letters, char[] currentCombination, bool[] used, HashSet<string> results, int index = 0)
        {
            if (index >= currentCombination.Length)
            {
                AddResult(currentCombination, results);
                return;
            }

            for (int i = 0; i < letters.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    currentCombination[index] = letters[i];
                    GenerateVariations(letters, currentCombination, used, results, index + 1);
                    used[i] = false;
                }
            }
        }

        private static void AddResult(char[] result, HashSet<string> results)
        {
            string currentCombination = new string(result);
            if (!usedCombinations.Contains(currentCombination))
            {
                results.Add(currentCombination);

                usedCombinations.Add(currentCombination);
                usedCombinations.Add(new string(new char[] { result[3], result[0], result[2], result[1] }));
                usedCombinations.Add(new string(new char[] { result[2], result[3], result[1], result[0] }));
                usedCombinations.Add(new string(new char[] { result[1], result[2], result[0], result[3] }));
            }
        }

        private static void PrintBlocks(HashSet<string> results)
        {
            Console.WriteLine("Number of blocks: {0}", results.Count);
            foreach (var combination in results)
            {
                Console.WriteLine(combination);
            }
        }
    }
}