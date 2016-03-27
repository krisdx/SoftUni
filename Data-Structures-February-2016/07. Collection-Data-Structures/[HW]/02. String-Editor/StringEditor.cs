namespace StringEditor
{
    using System;
    using System.Text;

    using Wintellect.PowerCollections;

    public class StringEditor
    {
        private static readonly BigList<char> result = new BigList<char>();

        public static void Main()
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandParams = command.Split();
                switch (commandParams[0])
                {
                    case "APPEND":
                        AddSymbols(commandParams[1]);
                        Console.WriteLine("OK");
                        break;
                    case "INSERT":
                        int indexToInsert = int.Parse(commandParams[1]);
                        if (indexToInsert < 0 || indexToInsert >= result.Count)
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }

                        InsertSymbols(indexToInsert, commandParams[2]);
                        Console.WriteLine("OK");
                        break;

                    case "DELETE":
                        int startIndex = int.Parse(commandParams[1]);
                        int count = int.Parse(commandParams[2]);
                        if (startIndex < 0 || startIndex >= result.Count ||
                            startIndex + count > result.Count)
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }

                        DeleteSymbols(startIndex, count);
                        Console.WriteLine("OK");
                        break;
                    case "REPLACE":
                        startIndex = int.Parse(commandParams[1]);
                        count = int.Parse(commandParams[2]);
                        if (startIndex < 0 || startIndex >= result.Count ||
                            startIndex + count > result.Count)
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }

                        Replace(startIndex, count, commandParams[3]);
                        Console.WriteLine("OK");
                        break;
                    case "PRINT":
                        Console.Write(Print());
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void Replace(int startIndex, int count, string replacementString)
        {
            result.RemoveRange(startIndex, count);
            result.InsertRange(startIndex, replacementString);
        }

        private static void DeleteSymbols(int startIndex, int count)
        {
            result.RemoveRange(startIndex, count);
        }

        private static void InsertSymbols(int indexToInsert, string stringToInsert)
        {
            result.InsertRange(indexToInsert, stringToInsert);
        }

        private static void AddSymbols(string stringToAdd)
        {
            result.AddRange(stringToAdd);
        }

        private static string Print()
        {
            var output = new StringBuilder();
            foreach (var symbol in result)
            {
                output.Append(symbol);
            }
            output.AppendLine();

            return output.ToString();
        }
    }
}