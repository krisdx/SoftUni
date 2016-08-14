using System;

public class ZigZagSequence
{
    private static int N;
    private static int K;
    private static bool[] used;
    // private static int[] sequence;

    private static int zigzagSequencesCount;

    public static void Main()
    {
        string[] args = Console.ReadLine().Trim().Split();
        N = int.Parse(args[0]);
        K = int.Parse(args[1]);

        used = new bool[N];
        // sequence = new int[K];

        SetBigger(0, -1);
        Console.WriteLine(zigzagSequencesCount);
    }

    private static void SetBigger(int index, int lastNumber)
    {
        if (index == K)
        {
            // Console.WriteLine(string.Join(", ", sequence));
            zigzagSequencesCount++;
            return;
        }

        for (int num = lastNumber + 1; num < N; num++)
        {
            if (!used[num])
            {
                used[num] = true;
                // sequence[index] = num;
                SetSmaller(index + 1, num);
                used[num] = false;
            }
        }
    }

    private static void SetSmaller(int index, int lastNumber)
    {
        if (index == K)
        {
            // Console.WriteLine(string.Join(", ", sequence));
            zigzagSequencesCount++;
            return;
        }

        for (int num = lastNumber - 1; num >= 0; num--)
        {
            if (!used[num])
            {
                used[num] = true;
                // sequence[index] = num;
                SetBigger(index + 1, num);
                used[num] = false;
            }
        }
    }
}