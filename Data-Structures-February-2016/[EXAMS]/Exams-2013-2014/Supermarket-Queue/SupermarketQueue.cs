namespace SupermarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Wintellect.PowerCollections;

    public class SupermarketQueue
    {
        public static void Main()
        {
            var bigList = new BigList<string>();
            var nameOccurences = new Dictionary<string, int>();

            var output = new StringBuilder();

            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] commandParams = line.Split();
                if (commandParams[0] == "Append")
                {
                    string name = commandParams[1];
                    bigList.Add(name);

                    if (!nameOccurences.ContainsKey(name))
                    {
                        nameOccurences.Add(name, 0);
                    }
                    nameOccurences[name]++;

                    output.AppendLine("OK");
                }
                else if (commandParams[0] == "Insert")
                {
                    string name = commandParams[2];
                    int position = int.Parse(commandParams[1]);
                    if (position < 0 || position > bigList.Count)
                    {
                        output.AppendLine("Error");
                    }
                    else
                    {
                        bigList.Insert(position, name);
                        if (!nameOccurences.ContainsKey(name))
                        {
                            nameOccurences.Add(name, 0);
                        }
                        nameOccurences[name]++;

                        output.AppendLine("OK");
                    }
                }
                else if (commandParams[0] == "Find")
                {
                    if (!nameOccurences.ContainsKey(commandParams[1]))
                    {
                        output.AppendLine("0");
                    }
                    else
                    {
                        output.AppendLine(nameOccurences[commandParams[1]].ToString());
                    }
                }
                else if (commandParams[0] == "Serve")
                {
                    int count = int.Parse(commandParams[1]);
                    if (count > bigList.Count)
                    {
                        output.AppendLine("Error");
                    }
                    else
                    {
                        var peopleInRange = bigList.GetRange(0, count);
                        foreach (var name in peopleInRange)
                        {
                            nameOccurences[name]--;
                        }

                        bigList.RemoveRange(0, count);
                        output.AppendLine(string.Join(" ", peopleInRange));
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}