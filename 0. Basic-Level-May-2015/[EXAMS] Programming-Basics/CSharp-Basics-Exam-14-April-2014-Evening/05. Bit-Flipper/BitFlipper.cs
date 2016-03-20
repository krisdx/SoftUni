using System;

class BitFlipper //-k.d
{
    static void Main()
    {
        ulong num = ulong.Parse(Console.ReadLine());

        int zerosCount = 0;
        int onesCount = 0;
        for (int bit = 63; bit >= 0; bit--)
        {
            ulong currentBit = (num >> bit ) & 1;
            if (currentBit == 0)
            {
                zerosCount++;
                onesCount = 0;
            }
            else
            {
                onesCount++;
                zerosCount = 0;
            }

            if (zerosCount == 3 || onesCount == 3)
            {
                num ^= ((ulong)7 << bit);
                onesCount = 0;
                zerosCount = 0;
            }
        }

        Console.WriteLine(num);
    }
}