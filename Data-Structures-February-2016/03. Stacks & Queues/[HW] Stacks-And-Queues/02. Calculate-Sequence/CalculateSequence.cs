namespace CalculateSequence
{
    using System;
    using System.Collections.Generic;

    public class CalculateSequence
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var resultNumbers = new List<int> { n };
            var queue = new Queue<int>();

            queue.Enqueue(n);
            while (queue.Count < 50)
            {
                var firstNum = queue.Peek() + 1;
                queue.Enqueue(firstNum);

                var secondNum = (queue.Peek() * 2) + 1;
                queue.Enqueue(secondNum);

                var thirdNum = queue.Peek() + 2;
                queue.Enqueue(thirdNum);

                queue.Dequeue();
                resultNumbers.Add(firstNum);
                resultNumbers.Add(secondNum);
                resultNumbers.Add(thirdNum);
            }

            Console.WriteLine(string.Join(", ", resultNumbers));
        }
    }
}