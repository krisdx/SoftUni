namespace EfficientStringEditing
{
    using System;
    using System.Text;
    using Wintellect.PowerCollections;

    public class EfficientStringEditing
    {
        public static void Main()
        {
            var rope = new BigList<char>();

            while (true)
            {
                string[] commandParams = Console.ReadLine().Split();
                if (commandParams[0] == "INSERT")
                {
                    string stringToInsert = commandParams[1];
                    rope.InsertRange(0, stringToInsert);
                }
                else if (commandParams[0] == "APPEND")
                {
                    string stringToAdd = commandParams[1];
                    for (int i = 0; i < stringToAdd.Length; i++)
                    {
                        rope.Add(stringToAdd[i]);
                    }
                }
                else if (commandParams[0] == "DELELTE")
                {
                    int startIndex = int.Parse(commandParams[1]);
                    if (startIndex < 0 || startIndex > rope.Count)
                    {
                        throw new IndexOutOfRangeException("The start index is invalid");
                    }

                    int count = int.Parse(commandParams[2]);
                    if (startIndex + count > rope.Count || count > rope.Count)
                    {
                        throw new IndexOutOfRangeException("The count is invalid");
                    }

                    rope.RemoveRange(startIndex, count);
                }
                else if (commandParams[0] == "PRINT")
                {
                    var output = new StringBuilder();

                    foreach (var symbol in rope)
                    {
                        output.Append(symbol);
                    }

                    Console.WriteLine(output);
                    break;
                }
                else
                {
                    break;
                }
            }
        }
    }
}