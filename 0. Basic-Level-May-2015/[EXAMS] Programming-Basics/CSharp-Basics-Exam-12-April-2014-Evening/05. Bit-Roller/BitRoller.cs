using System;

class BitRoller
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int freezePosition = int.Parse(Console.ReadLine());
        int rolls = int.Parse(Console.ReadLine());

        for (int roll = 0; roll < rolls; roll++)
        {
            num = RollNumberWithFrozenBit(num, freezePosition);
        }

        Console.WriteLine(num);
    }

    private static int RollNumberWithFrozenBit(int num, int freezePosition)
    {
        int rolledNum = 0;

        for (int bitPosition = 0; bitPosition < 19; bitPosition++)
        {
            int currentBit = (num >> bitPosition) & 1;

            if (bitPosition == freezePosition)
            {
                rolledNum |= currentBit << bitPosition;
            }
            else
            {
                int newPosition = GetNewPosition(bitPosition); 
                if (newPosition == freezePosition)
                {
                    newPosition = GetNewPosition(newPosition);
                }

                rolledNum |= currentBit << newPosition;
            }
        }

        return rolledNum;
    }

    private static int GetNewPosition(int bitPosition)
    {
        int newPostion = bitPosition - 1;

        if (newPostion < 0)
        {
            newPostion = 18;
        }

        return newPostion;
    }
}