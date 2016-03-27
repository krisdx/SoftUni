namespace RoundDance
{
    using System;
    using System.Collections.Generic;

    public class RoundDance
    {
        private static readonly Dictionary<int, List<int>> dancers = new Dictionary<int, List<int>>();
        private static Dictionary<int, bool> visited;

        public static void Main()
        {
            int numberOfFriendships = int.Parse(Console.ReadLine());
            visited = new Dictionary<int, bool>();
            int leader = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfFriendships; i++)
            {
                string[] edge = Console.ReadLine().Split();
                int parentValue = int.Parse(edge[0]);
                int childValue = int.Parse(edge[1]);

                if (!dancers.ContainsKey(childValue))
                {
                    dancers.Add(childValue, new List<int>());
                    visited[childValue] = false;
                }
                if (!dancers.ContainsKey(parentValue))
                {
                    dancers.Add(parentValue, new List<int>());
                    visited[parentValue] = false;
                }

                dancers[parentValue].Add(childValue);
                dancers[childValue].Add(parentValue);
            }

            int longestRoundDance = FindLongestRoundDance(leader);
            Console.WriteLine(longestRoundDance);
        }

        private static int FindLongestRoundDance(int currentDancer)
        {
            int bestRoundDance = 0;

            if (!visited[currentDancer])
            {
                visited[currentDancer] = true;
                foreach (var dancer in dancers[currentDancer])
                {
                    // Gets the child nodes count
                    int currentRoundDance = FindLongestRoundDance(dancer);

                    // Increments for the current node
                    currentRoundDance++;

                    if (currentRoundDance > bestRoundDance)
                    {
                        bestRoundDance = currentRoundDance;
                    }
                }
            }

            return bestRoundDance;
        }
    }
}