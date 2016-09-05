namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetCover
    {
        public static void Main()
        {
            var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            var sets = new[]
            {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

            var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine("Sets to take ({0}):", selectedSets.Count);
            foreach (var set in selectedSets)
            {
                Console.WriteLine("{{ {0} }}", string.Join(", ", set));
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                var currentBestSet = sets
                    .OrderByDescending(x => x.Count(universe.Contains))
                    .First();

                selectedSets.Add(currentBestSet);
                sets.Remove(currentBestSet);
                foreach (var num in currentBestSet)
                {
                    universe.Remove(num);
                }
            }

            return selectedSets;
        }
    }
}