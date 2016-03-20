using System;

class OddEvenSum //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double[] numbers = new double[n * 2];

        double oddSum = 0;
        double evenSum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = double.Parse(Console.ReadLine());
            if (i % 2 == 0)
            {
                oddSum += numbers[i];
            }
            else if (i % 2 == 1)
            {
                evenSum += numbers[i];
            }
        }

        if (evenSum == oddSum)
        {
            Console.WriteLine("Yes, sum={0}", evenSum);
        }
        else
        {
            if (evenSum > oddSum)
            {
                Console.WriteLine("No, diff={0}", evenSum - oddSum);
            }
            else
            {
                Console.WriteLine("No, diff={0}", oddSum - evenSum);
            }
        }
    }
}