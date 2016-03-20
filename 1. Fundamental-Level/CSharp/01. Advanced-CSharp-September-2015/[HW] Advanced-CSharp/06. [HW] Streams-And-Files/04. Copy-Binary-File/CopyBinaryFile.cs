using System;
using System.IO;

class ProgramCopyBinaryFile
{
    static void Main()
    {
        using (var file = new FileStream("../../CopyBinaryFile.cs", FileMode.Open))
        {
            using (var fileCopy = new FileStream("../.../CopyBinaryFile-Copy.cs", FileMode.Create))
            {
                file.CopyTo(fileCopy);
            }
        }
    }
}