using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class SlicingFile
{
    static List<string> filesPaths = new List<string>();

    static void Main()
    {
        string sourceFilePath = @"../../SlicingFile.cs";
        string destinationDirectory = @"../../";
        int parts = 5;//int.Parse(Console.ReadLine());

        Slice(sourceFilePath, destinationDirectory, parts);

        Assemble(destinationDirectory);
    }

    private static void Slice(string sourceFilePath, string destinationDirectory, int parts)
   