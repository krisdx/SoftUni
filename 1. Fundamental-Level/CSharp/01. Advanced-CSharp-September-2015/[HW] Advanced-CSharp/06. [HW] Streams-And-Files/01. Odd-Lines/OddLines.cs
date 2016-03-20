using System;
using System.IO;

// Write a program that reads a text file and prints on the console its odd lines. Line numbers starts from 0. Use StreamReader

class OddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader("FileToRead.txt");
        using (reader)
        {
            int oddCounter = 0;
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                oddCounter++;
                if (oddCounter % 2 != 0)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}