namespace OrderedSet
{
    using System;

    public class OrderedSetExample
    {
        public static void Main()
        {
            var orderedSet = new OrderedSet<int>();

            orderedSet.Add(5);
            orderedSet.Add(20);
            orderedSet.Add(1);

            orderedSet.Remove(1);
            orderedSet.Remove(5);
            orderedSet.Remove(20);

            try
            {
                foreach (var num in orderedSet)
                {
                    Console.WriteLine(num);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("The set is empty.");
            }
        }
    }
}