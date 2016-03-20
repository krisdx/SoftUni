using System;

class HalfSum
{
    static void Main() //-k.d
    {
        int n = int.Parse(Console.ReadLine());
        int[] firstSequence = new int[n];
        int firstSequenceSum = 0;
        for (int i = 0; i < n; i++)
        {
            firstSequence[i] = int.Parse(Console.ReadLine());
            firstSequenceSum += firstSequence[i];
        }

        int[] secondSequnece = new int[n];
        int secondSequenceSum = 0;
        for (int i = 0; i < n; i++)
        {
            secondSequnece[i] = int.Parse(Console.ReadLine());
            secondSequenceSum += secondSequnece[i];
        }

        if (firstSequenceSum == secondSequenceSum)
        {
            Console.WriteLine("Yes, sum={0}", secondSequenceSum);
        }
        else
        {
            if (firstSequenceSum > secondSequenceSum)
            {
                int result = firstSequenceSum - secondSequenceSum;
                Console.WriteLine("No, diff={0}", result);
            }
            else
            {
                int result = secondSequenceSum - firstSequenceSum;
                Console.WriteLine("No, diff={0}", result);
            }
        }
    }
}
