using System;

class BitSifting
{
    static void Main()
    {
        ulong initialNumber = ulong.Parse(Console.ReadLine());
        int numberOfSieves = int.Parse(Console.ReadLine());

        for (int sieve = 0; sieve < numberOfSieves; sieve++)
        {
            ulong nextSieve = ulong.Parse(Console.ReadLine());
            initialNumber &= (~nextSieve);
        }       

        Console.WriteLine(CountBits(initialNumber));
    }

    static int CountBits(ulong num)
    {
        int bitsCount = 0;
        ulong currentBit = 0;
        while (num > 0)
        {
            currentBit = num & 1;
            if (currentBit ==1 )
            {
                bitsCount++;
            }
            num >>= 1;
        }
        return bitsCount;
    }
}