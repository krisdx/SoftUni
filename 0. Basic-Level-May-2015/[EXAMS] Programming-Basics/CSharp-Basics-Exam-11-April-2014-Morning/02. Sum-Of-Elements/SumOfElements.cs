using System;

class SumOfElements
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] inputArray = input.Split(' ');


        long sum = 0;
        long max = long.MinValue;

        for (int i = 0; i < inputArray.Length; i++)
        {
            long number = long.Parse(inputArray[i]);
            sum += number;
            if (number > max)
            {
                max = number;
            }
        }

        if (sum == max * 2)
        {
            Console.WriteLine("Yes, sum={0}", max);
        }
        else
        {
            long diff = Math.Abs(sum - 2 * max);
            Console.WriteLine("No, diff={0}", diff);
        }
    }
}
