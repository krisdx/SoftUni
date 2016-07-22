namespace Blobs.IO
{
    using System;
    using System.Text;

    using Blobs.Interfaces.IO;

    public class OutputWriter : IOutputWriter
    {
        public void AppendLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}