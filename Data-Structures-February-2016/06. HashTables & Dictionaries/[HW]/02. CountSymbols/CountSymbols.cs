namespace CountSymbols
{
    using System;
    using System.Linq;

    using Dictionary;

    public class CountSymbols
    {
        public static void Main()
        {
            var dictionary = new CustomDictionary<char, int>();

            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (!dictionary.ContainsKey(currentChar))
                {
                    dictionary.Add(text[i], 0);
                }

                dictionary[currentChar]++;
            }

            var sortedCharOccurrences = dictionary.OrderBy(pair => pair.Key);
            foreach (var keyValue in sortedCharOccurrences)
            {
                Console.WriteLine(keyValue.Key + ": " + keyValue.Value);
            }
        }
    }
}