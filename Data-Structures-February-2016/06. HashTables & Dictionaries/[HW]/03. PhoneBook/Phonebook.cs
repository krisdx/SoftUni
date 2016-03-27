namespace Phonebook
{
    using System;

    using Dictionary;

    public class Phonebook
    {
        public static void Main()
        {
            var dictionary = new CustomDictionary<string, string>();

            string inputLine = Console.ReadLine();
            while (inputLine != "search")
            {
                string[] phoneParams = inputLine.Split('-');
                string personName = phoneParams[0];
                string phone = phoneParams[1];

                dictionary.AddOrReplace(personName, phone);

                inputLine = Console.ReadLine();
            }

            PerformSearch(dictionary);
        }

        private static void PerformSearch(CustomDictionary<string, string> hashTable)
        {
            string nameToSearch = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(nameToSearch))
            {
                if (!hashTable.ContainsKey(nameToSearch))
                {
                    Console.WriteLine("Contact {0} does not exists.", nameToSearch);
                }
                else
                {
                    Console.WriteLine(nameToSearch + " -> " + hashTable[nameToSearch]);
                }

                nameToSearch = Console.ReadLine();
            }
        }
    }
}