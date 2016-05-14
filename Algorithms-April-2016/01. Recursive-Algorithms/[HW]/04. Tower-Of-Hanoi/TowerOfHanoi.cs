namespace TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TowerOfHanoi
    {
        public static void Main()
        {
            int disksCount = 3;// int.Parse(Console.ReadLine());
            var source = new Stack<int>(Enumerable.Range(1, disksCount).Reverse());
            var spare = new Stack<int>();
            var destination = new Stack<int>();

            MoveDisks(disksCount, source, spare, destination);
            Console.WriteLine(string.Join(" ", destination));
        }

        private static void MoveDisks(int disk,
            Stack<int> source, Stack<int> spare, Stack<int> destination)
        {
            if (disk == 1)
            {
                destination.Push(source.Pop());
                return;
            }

            // Move all disks from source to spare
            MoveDisks(disk - 1, source, destination, spare);

            // Move the disk to the destination
            destination.Push(source.Pop());

            // Move back the disks from spare to destination
            MoveDisks(disk - 1, spare, source, destination);
        }
    }
}