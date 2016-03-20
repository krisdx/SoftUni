using System;

class CatchTheBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int index = 0;
        int bitsCounter = 0;
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int k = 7; k >= 0; k--)
            {
                if (index % step == 1 || ((step == 1) && index > 0))
                {
                    int currentBit = (number >> k) & 1;
                    result <<= 1;
                    result |= currentBit;
                    bitsCounter++;

                    if (bitsCounter == 8)
                    {
                        Console.WriteLine(result);
                        result = 0;
                        bitsCounter = 0;
                    }
                }

                index++;
            }
        }

        if (bitsCounter > 0)
        {
            result <<= (8 - bitsCounter);
            Console.WriteLine(result);
        }
    }
}