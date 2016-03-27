namespace SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortWorsd
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine().Trim()
                .Split()
                .ToList();

            // Using bubble sort algorithm.
            bool areSorted = false;
            while (!areSorted)
            {
                areSorted = true;
                for (int i = 0; i < words.Count - 1; i++)
                {
                    string firstWord = words[i];
                    string secondWord = words[i + 1];

                    if (firstWord[0] > secondWord[0])
                    {
                        SwapWords(words, i);
                        areSorted = false;
                    }
                    else if (firstWord[0] == secondWord[0])
                    {
                        int smallerWordLenght = GetSmallerWordLength(firstWord, secondWord);
                        for (int charIndex = 1; charIndex < smallerWordLenght; charIndex++)
                        {
                            while (charIndex < smallerWordLenght && firstWord[charIndex] == secondWord[charIndex])
                            {
                                charIndex++;
                            }

                            if (charIndex == smallerWordLenght)
                            {
                                // The words are the same 
                                break;
                            }

                            if (firstWord[charIndex] < secondWord[charIndex])
                            {
                                // The words are in the right order
                                break;
                            }

                            if (firstWord[charIndex] > secondWord[charIndex])
                            {
                                SwapWords(words, i);
                                areSorted = false;
                                break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", words));
        }

        private static void SwapWords(List<string> words, int i)
        {
            string swapValue = words[i];
            words[i] = words[i + 1];
            words[i + 1] = swapValue;
        }

        private static int GetSmallerWordLength(string firstWord, string secondWord)
        {
            if (secondWord.Length >= firstWord.Length)
            {
                return firstWord.Length;
            }

            return secondWord.Length;
        }
    }
}