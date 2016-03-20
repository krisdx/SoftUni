using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that takes as input two lists of integers and joins them. The result should hold all numbers from the first list, and all numbers from the second list, without repeating numbers, and arranged in increasing order. The input and output lists are given as integers, separated by a space, each list at a separate line. 

class JoinLists
{
    static void Main()
    {
        Console.WriteLine("Please, enter a list of integers, separated by space:");
        List<string> firstList = new List<string>(Console.ReadLine().Split(' '));
        
        Console.WriteLine("\nPlease, enter a second list of integers, separated by space:");
        List<string> secondList = new List<string>(Console.ReadLine().Split(' '));

        for (int i = 0; i < secondList.Count; i++)
        {
            for (int j = 0; j < firstList.Count; j++)
            {
                if (firstList[j] == secondList[i])
                {
                    firstList.Remove(secondList[i]);
                    j--;
                }
            }
        }
                
        firstList.AddRange(secondList);
        firstList.Sort();
        Console.WriteLine("\nResult:\n");
       
        foreach (var integer in firstList)
        {
            Console.Write("{0} ", integer);
        }
       
        Console.WriteLine("\n");
    }
}