using System;
using System.Collections.Generic;

class ArrayMatcher //-k.d
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] inputArrays = input.Split('\\');
        char[] firstArray = inputArrays[0].ToCharArray();
        char[] secondArray = inputArrays[1].ToCharArray();
        string command = inputArrays[2];

        List<char> newList = new List<char>();
        if (command == "join")
        {
            for (int first = 0; first < firstArray.Length; first++)
            {
                for (int second = 0; second < secondArray.Length; second++)
                {
                    if (firstArray[first] == secondArray[second])
                    {
                        newList.Add(firstArray[first]);
                    }
                }
            }
        }
        else if (command == "right exclude")
        {
            for (int first = 0; first < firstArray.Length; first++)
            {
                bool match = false;
                for (int second = 0; second < secondArray.Length; second++)
                {
                    if (firstArray[first] == secondArray[second])
                    {
                        match = true;
                    }
                }

                if (!match)
                {
                    newList.Add(firstArray[first]);
                }
            }
        }
        else //if (command == "left exclude")
        {
            for (int second = 0; second < secondArray.Length; second++)
            {
                bool match = false;
                for (int first = 0; first < firstArray.Length; first++)
                {
                    if (secondArray[second] == firstArray[first])
                    {
                        match = true;
                    }
                }

                if (!match)
                {
                    newList.Add(secondArray[second]);
                }
            }
        }

        newList.Sort();
        foreach (char letter in newList)
        {
            Console.Write(letter);
        }
    }
}