namespace _01.LinkedQueue
{
    using System;

    public class QueueMain
    {
        public static void Main()
        {
            var linkedQueue = new LinkedQueue<int>();

            linkedQueue.Enqueue(1);
            Console.WriteLine(linkedQueue.Peek());
        }
    }
}