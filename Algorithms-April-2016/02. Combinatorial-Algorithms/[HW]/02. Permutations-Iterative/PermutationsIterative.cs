namespace PermutationsIterative
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PermutationsIterative
    {
        public static void Main()
        {
            int n =  int.Parse(Console.ReadLine());
            var numbers = Enumerable.Range(1, n).ToList();

            var permutations = GeneratePermutations<int>(numbers);
            foreach (var permutation in permutations)
            {
                Console.WriteLine(string.Join(" ", permutation));
            }
        }

        private static List<List<T>> GeneratePermutations<T>(List<T> source)
        {
            var permutations = new List<List<T>>();
            permutations.Add(new List<T>() { source[0] });
            for (int i = 1; i < source.Count; i++)
            {
                var currentElement = source[i];
                for (int j = permutations.Count - 1; j >= 0; j--)
                {
                    var currentPermutation = permutations[j];
                    permutations.RemoveAt(j);

                    for (int insertIndex = currentPermutation.Count; insertIndex >= 0; insertIndex--)
                    {
                        var newPermutation = new List<T>(currentPermutation);
                        newPermutation.Insert(insertIndex, currentElement);

                        permutations.Add(newPermutation);
                    }
                }
            }

            return permutations;
        }
    }
}