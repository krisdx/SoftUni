ntent.ToArray(), slicedFilesSize * i, slicedFilesSize);
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
           