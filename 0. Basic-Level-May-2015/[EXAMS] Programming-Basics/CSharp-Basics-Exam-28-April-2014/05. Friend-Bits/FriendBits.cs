using System;

class FriendBits
{
    static void Main()
    {
        uint num = uint.Parse(Console.ReadLine());
        uint friendBits = 0;
        uint aloneBits = 0;
        for (int bitPosition = 31; bitPosition >= 0; bitPosition--)
        {
            uint currentBit = (num >> bitPosition) & 1;

            bool hasLeftBit = (bitPosition < 31);
            uint leftBit = (num >> bitPosition + 1) & 1;
            bool isLeftBitEqual = hasLeftBit && (leftBit == currentBit);

            bool hasRightBit = (bitPosition > 0);
            uint rigthBit = (num >> bitPosition - 1) & 1;
            bool isRightBitEqual = hasRightBit && (rigthBit == currentBit);

            if (isLeftBitEqual || isRightBitEqual)
            {
                friendBits <<= 1;
                friendBits |= currentBit;
            }
            else
            {
                aloneBits <<= 1;
                aloneBits |= currentBit;
            }
        }

        Console.WriteLine(friendBits);
        Console.WriteLine(aloneBits);
    }
}