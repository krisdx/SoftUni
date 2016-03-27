namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main()
        {
            try
            {
                int[] numbers = Console.ReadLine().Trim()
                .Split()
                .Select(int.Parse)
                .ToArray();

                var stack = new Stack<int>();
                for (int index = 0; index < numbers.Length; index++)
                {
                    stack.Push(numbers[index]);
                }

                while (stack.Count > 0)
                {
                    var popedElement = stack.Pop();
                    Console.Write(popedElement + " ");
                }

                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }
    }
}