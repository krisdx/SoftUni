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
    {

        List<byte> fileContent = new List<byte>();
        using (var sourceFile = new FileStream(sourceFilePath, FileMode.Open))
        {
            byte[] buffer = new byte[4096];
            while (true)
            {
                int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                if (readBytes == 0)
                {
                    break;
                }

                for (int i = 0; i < readBytes; i++)
                {
                    fileContent.Add(buffer[i]);
                }
            }
        }

        int slicedFilesSize = fileContent.Count / parts;
        int remainingBytes = fileContent.Count - (slicedFilesSize * parts);
        for (int i = 0; i < parts; i++)
        {
            string filePath = destinationDirectory + string.Format(@"Part-{0}.cs", i);
            using (var slicedFile = new FileStream(filePath, FileMode.Create))
            {
                if (i == parts - 1)
                {
                    slicedFile.Write(fileContent.ToArray(), slicedFilesSize * i, slicedFilesSize + remainingBytes);
                    continue;
                }

                slicedFile.Write(fileContent.ToArray(), slicedFilesSize * i, slicedFilesSize);
            }

            filesPaths.Add(filePath);
        }
    }

    private static void Assemble(string destinationDirectory)
    {
        string assembledFilePath = destinationDirectory + "assembled.cs";

        List<byte> assembledFileData = new List<byte>();
        for (int i = 0; i < filesPaths.Count; i++)
        {
            using (var currentFile = new FileStream(filesPaths[i], FileMode.Open))
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int readBytes = currentFile.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }

                    for (int j = 0; j < readBytes; j++)
                    {
                        assembledFileData.Add(buffer[j]);
                    }
                }
            }
        }

        using (var assembledFile = new FileStream(assembledFilePath, FileMode.Create))
        {
            assembledFile.Write(assembledFileData.ToArray(), 0, assembledFileData.Count);
        }
    }
}