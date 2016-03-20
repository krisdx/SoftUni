using System;
using System.Collections.Generic;

// Write a program that takes as input two lists of names and removes from the first list all names given in the second list. The input and output lists are given as words, separated by a space, each list at a separate line.

class RemoveNames
{
    static void Main()
    {

        List<string> firstList = new List<string>(Console.ReadLine().Split(' '));
        List<string> secondList = new List<string>(Console.ReadLine().Split(' '));


        for (int i = 0; i < secondList.Count; i++)
        {
            for (int j = 0; j < firstList.Count; j++)
            {
                if (firstList[j] == secondList[i]) 
                {
                    firstList.RemoveAt(j);
                    j--;
                }
            }
        }
        foreach (var name in firstList)
        {
            Console.Write("{0} ",name);
        }
        Console.WriteLine();
    }
}
