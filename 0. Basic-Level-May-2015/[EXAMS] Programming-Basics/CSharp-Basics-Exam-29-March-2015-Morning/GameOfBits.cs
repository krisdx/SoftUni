using System;

class GameOfBits //-k.d
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());

        uint newNum = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Game Over!")
            {
                CountOnes(number);
                break;
            }
            else if (input == "Odd")
            {
                int oddBitsCounter = 0;
                for (int bit = 0; bit < 32; bit += 2)
                {
                    uint currentBit = (number >> bit) & 1;
                    newNum |= (currentBit << oddBitsCounter);
                    oddBitsCounter++;
                }

                number = newNum;
                newNum = 0;
            }
            else
            {
                int evenBitsCounter = 0;
                for (int bit = 1; bit < 32; bit += 2)
                {
                    uint currentBit = (number >> bit) & 1;
                    newNum |= (currentBit << evenBitsCounter);
                    evenBitsCounter++;
                }

                number = newNum;
                newNum = 0;
            }
        }
    }

    private static void CountOnes(uint num)
    {
        uint currentNumber = num;
        int onesCount = 0;
        while (currentNumber > 0)
        {
            uint currentBit = currentNumber & 1;
            if (currentBit == 1)
            {
                onesCount++;
            }
            currentNumber >>= 1;
        }
        Console.WriteLine("{0} -> {1}", num, onesCount);
    }
}