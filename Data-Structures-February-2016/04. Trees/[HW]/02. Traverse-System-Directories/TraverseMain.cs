namespace TraverseSystemDirectories
{
    using System;
    using System.Text;
    using System.IO;

    public class TraverseMain
    {
        private const string TraverseDirectory = "D:\\Visual Studio 2015";

        private static readonly StringBuilder output = new StringBuilder();
        private static int totalFoldersCount;
        private static int totalFilesCount;

        public static void Main()
        {
            var rootFolder = new Folder(TraverseDirectory);

            CreateTreeFromFolder(rootFolder);

            Console.WriteLine(output);
            Console.WriteLine(@"Total Folders in ""{0}"": {1}", TraverseDirectory, totalFoldersCount);
            Console.WriteLine(@"Total Files in ""{0}"": {1}", TraverseDirectory, totalFilesCount);

            Console.WriteLine();
            Console.WriteLine(@"The sum of the files in ""{0}"": {1}", TraverseDirectory, rootFolder.GetFilesSize());
            //// Using the static method
            // Console.WriteLine(Folder.GetFilesSize(rootFolder));
        }

        private static void CreateTreeFromFolder(Folder parentFolder)
        {
            var currentDirectory = new DirectoryInfo(parentFolder.Name);

            foreach (var fileInfo in currentDirectory.GetFiles())
            {
                var file = new File(fileInfo.Name, fileInfo.Length);
                parentFolder.Files.Add(file);

                totalFilesCount++;
            }

            output.AppendLine(parentFolder.Name);
            // output.AppendLine("Number of Files In Folder: " + parentFolder.Files.Count);
            totalFoldersCount++;

            foreach (var subDirectory in currentDirectory.GetDirectories())
            {
                var subFolder = new Folder(subDirectory.FullName);
                parentFolder.Folders.Add(subFolder);

                CreateTreeFromFolder(subFolder);
            }
        }
    }
}