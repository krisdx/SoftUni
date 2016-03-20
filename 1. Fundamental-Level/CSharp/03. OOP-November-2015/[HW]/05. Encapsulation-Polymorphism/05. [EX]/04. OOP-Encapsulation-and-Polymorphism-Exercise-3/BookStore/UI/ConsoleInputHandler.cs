namespace BookStore.UI
{
    using System;
    using BookStore.Interfaces;

    public class ConsoleInputHandler : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
