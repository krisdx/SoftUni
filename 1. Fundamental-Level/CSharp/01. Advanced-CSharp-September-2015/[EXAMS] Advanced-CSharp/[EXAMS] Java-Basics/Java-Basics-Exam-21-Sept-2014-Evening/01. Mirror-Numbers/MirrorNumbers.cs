using System;
using System.Linq;

class MirrorNumbers
{
    static void Main()
    {
        string n = Console.ReadLine();
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        bool solutionFound = false;
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                string nextNum = ReverseNum(numbers[j]);
                if (numbers[i].ToString() == nextNum)
                {
                    Console.WriteLine("{0}<!>{1}", numbers[i], numbers[j]);
                    solutionFound = true;
                }
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }

    static string ReverseNum(int num)
    {
        string reversedNum = string.Empty;
        while (num > 0)
        {
            reversedNum += Convert.ToString(num % 10);
            num /= 10;
        }

        return reversedNum;
    }
}