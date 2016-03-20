using System;

class NakovsMatching //-k.d
{
    static void Main()
    {
        string firstWord = Console.ReadLine();
        string secondWord = Console.ReadLine();
        int limit = int.Parse(Console.ReadLine());

        bool solutionFound = false;
        for (int f1 = 1; f1 < firstWord.Length; f1++)
        {
            for (int f2 = 1; f2 < secondWord.Length; f2++)
            {
                string firstLeft = firstWord.Substring(0, f1);
                string firstRight = firstWord.Substring(f1);
                string secondLeft = secondWord.Substring(0, f2);
                string secondRight = secondWord.Substring(f2);

                long currentFirstLeft = GetLeftValue(firstLeft);
                long currentFirstRight = GetRightValue(firstRight);
                long currentSecondLeft = GetLeftValue(secondLeft);
                long currentSecondRight = GetRightValue(secondRight);
                long currentTotal = Math.Abs((currentFirstLeft * currentSecondRight) - (currentFirstRight * currentSecondLeft));

                if (currentTotal <= limit)
                {
                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs", firstLeft, firstRight, secondLeft, secondRight, currentTotal);
                    solutionFound = true;
                }
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }

    private static long GetLeftValue(string left)
    {
        long leftValue = 0;
        for (int i = 0; i < left.Length; i++)
        {
            leftValue += left[i];
        }
        return leftValue;
    }

    private static long GetRightValue(string right)
    {
        long rightValue = 0;
        for (int i = 0; i < right.Length; i++)
        {
            rightValue += right[i];
        }
        return rightValue;
    }
}