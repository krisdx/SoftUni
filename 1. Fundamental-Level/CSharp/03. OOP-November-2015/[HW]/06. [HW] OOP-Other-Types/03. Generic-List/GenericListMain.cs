using System;

public class GenericListMain
{
    static void Main()
    {
        GenericList<int> numbers = new GenericList<int>();
        for (int i = 1; i <= 20; i++)
        {
            numbers.Add(i);
        }

        Console.WriteLine("Min: {0}", numbers.Min());
        Console.WriteLine("Max: {0}", numbers.Max());
        Console.WriteLine("Capacity: {0}", numbers.Capacity);
        Console.WriteLine("Length: {0}", numbers.Count);
        numbers.Insert(0, -100000000);
        Console.WriteLine();
        Console.WriteLine(numbers);
        numbers.Clear();
        Console.WriteLine(numbers);
    }
}