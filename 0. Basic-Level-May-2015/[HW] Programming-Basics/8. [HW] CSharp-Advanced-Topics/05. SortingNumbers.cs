using System;
using System.Collections.Generic;

class SortingNumbers
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        int n = int.Parse(Console.ReadLine());

        List<int> listOfNumvers = new List<int>(n);
        Console.WriteLine();
        
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number ({0}): ", i + 1);
            listOfNumvers.Add(int.Parse(Console.ReadLine()));
        }
       
        Console.WriteLine();
        listOfNumvers.Sort();
        Console.WriteLine("Sorted by size: \n");

        for (int i = 0; i < listOfNumvers.Count; i++)
        {
            Console.WriteLine(listOfNumvers[(i)]);
        }
        Console.WriteLine();
    }
}