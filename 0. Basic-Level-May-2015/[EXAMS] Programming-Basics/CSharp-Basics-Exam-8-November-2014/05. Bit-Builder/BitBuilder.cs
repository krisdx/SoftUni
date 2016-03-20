using System;

class BitBuilder
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "quit")
            {
                break;
            }
            int position = int.Parse(input);
            string command = Console.ReadLine();

            if (command == "flip")
            {
                number ^= (long)1 << position;
            }
            else if (command == "remove")
            {
                number = RemoveBit(number, position);
            }
            else if (command == "insert")
            {
                number = InsertBit(number, position);
            }
            else
            {
                continue;
            }
        }

        Console.WriteLine(number);
    }

    static long InsertBit(long num, int bitPosition)
    {
        long resultNum = num;

        int bitsLength = 0;
        while (resultNum > 0)
        {
            bitsLength++;
            resultNum >>= 1;
        }

        bool bitIsInserted = false;
        for (int bit = 0; bit < bitsLength; bit++)
        {
            resultNum >>= 1;

            if (bit == bitPosition)
            {
                resultNum |= (long)1 << bitsLength;
                bitPosition = -1;
                bit--;
                bitIsInserted = true;
            }
            else
            {
                long currnetBit = (num >> bit) & 1;
                resultNum |= currnetBit << bitsLength;
            }
        }

        if (!bitIsInserted)
        {
            resultNum >>= 1;
            resultNum |= (long)1 << bitPosition;
        }

        return resultNum;
    }

    static long RemoveBit(long num, int bitPosition)
    {
        long resultNum = num;

        int bitsLength = 0;
        while (resultNum > 0)
        {
            bitsLength++;
            resultNum >>= 1;
        }

        bool bitRemoved = false;
        for (int bit = 0; bit < bitsLength; bit++)
        {

            long currnetBit = (num >> bit) & 1;
            if (bit != bitPosition)
            {
                resultNum >>= 1;
                resultNum |= currnetBit << bitsLength - 1;
            }
            else
            {
                bitRemoved = true;
            }
        }

        if (bitRemoved)
        {
            resultNum >>= 1;
        }
        return resultNum;
    }

    private static int countBits(long number)
    {
        long numToCount = number;
        int BitsLength = 0;

        while (numToCount > 0)
        {
            BitsLength++;
            numToCount >>= 1;
        }

        return BitsLength;
    }
}