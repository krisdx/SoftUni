using System;

class X_Bits
{
    static void Main()
    {
        int[] numbers = new int[8];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int xBitsCount = 0;
        for (int num = 0; num < numbers.Length - 2; num++)
        {
            for (int bit = 0; bit < 32; bit++)
            {
                int check1 = (numbers[num] & (7 << bit)) >> bit;
                int check2 = (numbers[num + 1] & (7 << bit)) >> bit;
                int check3 = (numbers[num + 2] & (7 << bit)) >> bit;
                if (check1 == 5 && check2 == 2 && check3 == 5)
                {
                    xBitsCount++;
                }
            }
        }
        Console.WriteLine(xBitsCount);
    }
}