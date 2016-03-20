using System;

class Pairs // -k.d
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] inputArray = input.Split(' ');
        int[] numbers = new int[inputArray.Length];

        int sum1 = 0;
        int sum2 = 0;
        int count = 0;
        int maxDiff = 0;
        int diff = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            count++;
            numbers[i] = int.Parse(inputArray[i]);

            if (count % 2 == 0)
            {
                sum1 = numbers[i] + numbers[i - 1];
                if (sum1 == sum2)
                {

                }
                else
                {
                    if (i >= 3)
                    {
                        if (sum1 > sum2)
                        {
                            diff = sum1 - sum2;
                        }
                        else
                        {
                            diff = sum2 - sum1;
                        }
                    }
                }
                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }

                if (i + 1 == numbers.Length && numbers.Length > 2)
                {

                }
                else
                {
                    sum2 = sum1;
                }
            }
        }
        if (sum1 == sum2)
        {
            Console.WriteLine("Yes, value={0}", sum1);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", maxDiff);
        }
    }
}