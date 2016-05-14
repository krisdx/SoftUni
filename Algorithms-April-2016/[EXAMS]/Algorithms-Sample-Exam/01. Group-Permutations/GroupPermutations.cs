namespace GroupPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GroupPermutations
    {
        private static Dictionary<char, int> dict = new Dictionary<char, int>();
        private static StringBuilder output = new StringBuilder();

        public static void Main()
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict.Add(input[i], 1);
                }
                else
                {
                    dict[input[i]]++;
                }
            }

            GeneratePermutations(dict.Keys.ToArray(), 0);
            Console.WriteLine(output.ToString().Trim());
        }

        private static void GeneratePermutations(char[] letters, int startIndex)
        {
            if (startIndex >= letters.Length)
            {
                Print(letters);
                return;
            }

            for (int currentIndex = startIndex; currentIndex < letters.Length; currentIndex++)
            {
                Swap(ref letters[startIndex], ref letters[currentIndex]);
                GeneratePermutations(letters, startIndex + 1);
                Swap(ref letters[startIndex], ref letters[currentIndex]);
            }
        }

        private static void Print(char[] letters)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = 0; j < dict[letters[i]]; j++)
                {
                    output.Append(letters[i]);
                }
            }

            output.AppendLine();
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}