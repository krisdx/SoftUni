using System;
using System.IO;

// Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file. Use StreamReader in combination with StreamWriter.

class LineNumbers
{
    static void Main()
    {
        StreamReader reader = new StreamReader("../../TextFileWithoutLines.txt");
        using (reader)
        {
            StreamWriter writer = new StreamWriter("../../TextFileWithLines.txt");
            using (writer)
            {
                int lineCounter = 1;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    writer.WriteLine("{0}. {1}",lineCounter, line);
                    lineCounter++;
                }
            }
        }
    }
}