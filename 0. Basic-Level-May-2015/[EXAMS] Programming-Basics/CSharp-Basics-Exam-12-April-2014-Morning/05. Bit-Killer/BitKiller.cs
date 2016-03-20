using System;

class BitsKiller
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int bitsCounter = 0;
        int resultNum = 0;
        int index = 0;
        for (int num = 0; num < n; num++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int bitPos = 7; bitPos >= 0; bitPos--)
            {
                if (!((index % step == 1) || (step == 1 && index > 0))) //for every position that is not step we do :
                {
                    int currentBit = (number >> bitPos) & 1;
                    resultNum <<= 1;
                    resultNum |= currentBit;
                    bitsCounter++;
                    if (bitsCounter == 8) 
                    {
                        Console.WriteLine(resultNum);
                        bitsCounter = 0;
                        resultNum = 0;
                    }
                }
                index++;
            }
        }

        if (bitsCounter > 0)
        {
            resultNum = resultNum << (8 - bitsCounter);
            Console.WriteLine(resultNum);
        }
    }
}