namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Salaries
    {
        private static List<int>[] graph;
        private static Dictionary<int, long> salaries = new Dictionary<int, long>();
        private static HashSet<int> visited = new HashSet<int>();

        public static void Main()
        {
            ReadInput();

            FindSalaries();

            long result = GetResult();
            Console.WriteLine(result);
        }

        private static List<int>[] ReadInput()
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            return graph;
        }

        private static void FindSalaries()
        {
            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited.Contains(i))
                {
                    DFS(i);
                }
            }
        }

        private static void DFS(int index)
        {
            if (!visited.Contains(index))
            {
                visited.Add(index);
                if (graph[index].Count == 0)
                {
                    salaries[index] = 1;
                }
                else
                {
                    foreach (var successor in graph[index])
                    {
                        if (!salaries.ContainsKey(index))
                        {
                            salaries[index] = 0;
                        }

                        DFS(successor);
                        salaries[index] += salaries[successor];
                    }
                }
            }
        }

        private static long GetResult()
        {
            long result = 0;
            foreach (var person in salaries)
            {
                result += person.Value;
            }

            return result;
        }
    }
}