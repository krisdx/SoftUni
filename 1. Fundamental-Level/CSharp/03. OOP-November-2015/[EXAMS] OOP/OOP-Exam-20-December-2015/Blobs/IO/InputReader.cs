namespace Blobs.IO
{
    using System;

    using Blobs.Interfaces.IO;

    public class InputReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}