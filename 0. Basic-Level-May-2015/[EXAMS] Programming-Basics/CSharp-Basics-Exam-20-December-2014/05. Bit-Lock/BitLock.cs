using System;
using System.Linq;

class BitLock //-k.d
{
    static void Main()
    {
        string inputNumbers = Console.ReadLine();

        int[] numbers = inputNumbers.Split(' ').Select(int.Parse).ToArray();

        while (true)
        {
            string inputCommands = Console.ReadLine();
            if (inputCommands == "end")
            {
                foreach (int number in numbers)
                {
                    Console.Write(number + " ");
                }
                break;
            }

            string[] commandsArray = inputCommands.Split(' ');

            if (commandsArray[0] == "check")
            {
                int position = int.Parse(commandsArray[1]);
                int onesCounter = 0;

                for (int row = 0; row < numbers.Length; row++)
                {
                    int bit = (numbers[row] >> position) & 1;
                    if (bit == 1)
                    {
                        onesCounter++;
                    }
                }

                Console.WriteLine(onesCounter);
            }
            else
            {
                int rowToRoll = int.Parse(commandsArray[0]);
                int rolls = int.Parse(commandsArray[2]);

                for (int roll = 0; roll < rolls; roll++)
                {
                    numbers[rowToRoll] = RollBits(numbers[rowToRoll], commandsArray[1]);
                }
            }
        }
    }

    static int RollBits(int num, string direction)
    {
        int bitsLength = 11;
        int rolledNum = num;

        if (direction == "right")
        {
            int lastBit = num & 1;
            rolledNum >>= 1;
            rolledNum |= lastBit << bitsLength;
        }
        else //if (direction == left)
        {
            int firstBit = (num >> bitsLength) & 1;
            rolledNum &= ~(1 << bitsLength);
            rolledNum <<= 1;
            rolledNum |= firstBit;
        }

        return rolledNum;
    }
}