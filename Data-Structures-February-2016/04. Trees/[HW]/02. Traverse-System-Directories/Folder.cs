namespace TraverseSystemDirectories
{
    using System.Collections.Generic;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.Folders = new List<Folder>();
        }

        public string Name { get; private set; }

        public List<File> Files { get; set; }

        public List<Folder> Folders { get; set; }

        /// <summary>
        /// Gets the sum of the specified folder's files.
        /// </summary>
        /// <param name="folder">The folder</param>
        /// <returns>Returns the sum of the files in bytes</returns>
        public static long GetFilesSize(Folder folder)
        {
            long sum = 0;

            foreach (var file in folder.Files)
            {
                sum += file.Size;
            }

            foreach (var subFolder in folder.Folders)
            {
                sum += subFolder.GetFilesSize();
            }

            return sum;
        }

        /// <summary>
        /// Gets the sum of the current folder's files.
        /// </summary>
        /// <returns>Returns the sum of the files in bytes</returns>
        public long GetFilesSize()
        {
            long sum = 0;

            foreach (var file in this.Files)
            {
                sum += file.Size;
            }

            foreach (var folder in this.Folders)
            {
                sum += folder.GetFilesSize();
            }

            return sum;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}