using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

class RopeExample
{
    static void Main()
    {
        const int InsertCount = 100000;

        Console.WriteLine("Start of string inserts:");
        Console.WriteLine("------------------------");

        var startTime = DateTime.Now;
        var ropeOfChars = new BigList<char>();
        for (int i = 0; i < InsertCount; i++)
        {
            ropeOfChars.Insert(0, (char)('a' + (i % 10)));
        }
        Console.WriteLine("Rope<char> time: {0}", DateTime.Now - startTime);

        startTime = DateTime.Now;
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < InsertCount; i++)
        {
            stringBuilder.Insert(0, (char)('a' + (i % 10)));
        }
        Console.WriteLine("StringBuilder time: {0}", DateTime.Now - startTime);

        startTime = DateTime.Now;
        var ropeOfInts = new BigList<int>();
        for (int i = 0; i < InsertCount; i++)
        {
            ropeOfInts.Insert(0, i);
        }
        Console.WriteLine("Rope<int> time: {0}", DateTime.Now - startTime);

        startTime = DateTime.Now;
        var listOfInts = new List<int>();
        for (int i = 0; i < InsertCount; i++)
        {
            listOfInts.Insert(0, i);
        }
        Console.WriteLine("List<int> time: {0}", DateTime.Now - startTime);

        Console.WriteLine();
        Console.WriteLine("Middle of string inserts:");
        Console.WriteLine("-------------------------");

        startTime = DateTime.Now;
        ropeOfChars = new BigList<char>();
        for (int i = 0; i < InsertCount; i++)
        {
            ropeOfChars.Insert(ropeOfChars.Count / 2, (char)('a' + (i % 10)));
        }
        Console.WriteLine("Rope<char> time: {0}", DateTime.Now - startTime);

        startTime = DateTime.Now;
        stringBuilder = new StringBuilder();
        for (int i = 0; i < InsertCount; i++)
        {
            stringBuilder.Insert(stringBuilder.Length / 2, (char)('a' + (i % 10)));
        }
        Console.WriteLine("StringBuilder time: {0}", DateTime.Now - startTime);
    }
}
