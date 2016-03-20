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