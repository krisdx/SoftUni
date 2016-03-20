ze = fileContent.Count / parts;
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

                slicedFile.Write(fileCo