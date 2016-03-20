using System;

class ByteParty //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "party over")
            {
                break;
            }

            string[] commandDetails = input.Split(' ');
            int command = int.Parse(commandDetails[0]);
            int bitPosition = int.Parse(commandDetails[1]);

            for (int i = 0; i < numbers.Length; i++)
            {
                if (command == -1)
                {
                    numbers[i] ^= 1 << bitPosition;
                }
                else if (command == 0)
                {
                     numbers[i] &= ~(1 << bitPosition);
                }
                else
                {
                    numbers[i] |= 1 << bitPosition;
                }
            }
        }

        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}