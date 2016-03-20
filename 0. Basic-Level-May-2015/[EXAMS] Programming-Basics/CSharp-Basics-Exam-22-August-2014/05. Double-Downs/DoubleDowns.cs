using System;

class DoubleDowns //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int verticalBitsCount = 0;
        int rightDiagonalBitsCount = 0;
        int leftDiagonalBitsCount = 0;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int verticalBits = numbers[i] & numbers[i + 1];
            verticalBitsCount += CountOnes(verticalBits);

            int rightDiagonalBits = numbers[i] & (numbers[i + 1]<<1);
            rightDiagonalBitsCount += CountOnes(rightDiagonalBits);

            int leftDiagonalBits = (numbers[i] << 1) & numbers[i + 1];
            leftDiagonalBitsCount += CountOnes(leftDiagonalBits);
        }

        Console.WriteLine(rightDiagonalBitsCount);
        Console.WriteLine(leftDiagonalBitsCount);
        Console.WriteLine(verticalBitsCount);
    }

    static int CountOnes(int num)
    {
        int onesCount = 0;
        for (int i = 0; i < 32; i++)
        {
            int mask = ((1 << i) & num) >> i;
            if (mask == 1) onesCount++;
        }
        return onesCount;
    }
}