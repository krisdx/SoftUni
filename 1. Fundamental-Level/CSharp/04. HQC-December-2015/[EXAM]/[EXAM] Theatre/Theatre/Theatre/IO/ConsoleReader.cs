namespace Theatre.IO
{
    using System;
    using Theatre.Interfaces.IO;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}