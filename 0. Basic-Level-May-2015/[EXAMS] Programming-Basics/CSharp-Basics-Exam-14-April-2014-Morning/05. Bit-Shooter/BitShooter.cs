using System;

class BitShooter
{
    static void Main()
    {
        ulong num = ulong.Parse(Console.ReadLine());

        for (int shoot = 0; shoot < 3; shoot++)
        {
            string[] shootDetails = Console.ReadLine().Split(' ');
            int shootCenter = int.Parse(shootDetails[0]);
            int shootSize = int.Parse(shootDetails[1]);

            int startBit = shootCenter - (shootSize / 2); // !
            int endBit = shootCenter + (shootSize / 2); // !
            for (int bit = startBit; bit <= endBit; bit++)
            {
                if (bit >= 0 && bit < 64)
                {
                    num &= ~((ulong)1 << bit);
                }
            }
        }

        int rightOnesCounter = 0;
        for (int bit = 0; bit < 32; bit++)
        {
            ulong currentBit = (num >> bit) & 1;
            if (currentBit == 1)
            {
                rightOnesCounter++;
            }
        }

        int leftOnesCounter = 0;
        for (int bit = 32; bit < 64; bit++)
        {
            ulong currentBit = (num >> bit) & 1;
            if (currentBit == 1)
            {
                leftOnesCounter++;
            }
        }

        Console.WriteLine("left: {0}", leftOnesCounter);
        Console.WriteLine("right: {0}", rightOnesCounter);
    }
}