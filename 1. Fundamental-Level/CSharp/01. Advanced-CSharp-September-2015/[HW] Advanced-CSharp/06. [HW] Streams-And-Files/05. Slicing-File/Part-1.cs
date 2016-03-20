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

        int slicedFilesSi