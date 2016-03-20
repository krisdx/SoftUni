namespace Theatre.IO
{
    using System;
    using Theatre.Interfaces.IO;

    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}