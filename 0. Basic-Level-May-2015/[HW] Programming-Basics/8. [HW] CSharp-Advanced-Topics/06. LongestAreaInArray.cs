using System;

// Write a program to find the longest area of equal elements in array of strings. You first should read an integer n and n strings (each at a separate line), then find and print the longest sequence of equal elements (first its length, then its elements). If multiple sequences have the same maximal length, print the leftmost of them.

class LongestAreaInArray
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine();

        string[] inputArray = new string[n];
        

        for (int i = 0; i < n; i++)
        {
            inputArray[i] = Console.ReadLine();
        }

        int resultCount = 0;
        string resultValue = inputArray[0];

        int countEqualMembers = 1;
        int maxCount = countEqualMembers;

        //we search the array member by member
        for (int i = 1; i < n; i++)
        {
            string currentMember = inputArray[i];
            string prevMember = inputArray[i - 1];

            if (prevMember == currentMember)
            {
                countEqualMembers++;
                if (countEqualMembers > maxCount)
                {
                    maxCount = countEqualMembers;
                    resultCount = countEqualMembers;
                    resultValue = currentMember;
                }
            }
            else if (prevMember != currentMember)
            {
                countEqualMembers = 1;
            }
        }
        Console.WriteLine();
        Console.WriteLine(maxCount);
        for (int i = 0; i < maxCount; i++)
        {
            Console.WriteLine(resultValue);
        }
    }
}