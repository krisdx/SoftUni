using System;

class BitCarousel
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int rotations = int.Parse(Console.ReadLine());

        for (int i = 0; i < rotations; i++)
        {
            string direction = Console.ReadLine();

            if (direction.Equals("right"))
            {
                int rightMostBit = num & 1;
                num >>= 1;
                num |= (rightMostBit << 5);
            }
            else if (direction.Equals("left"))
            {
                int leftMostBit = (num >> 5) & 1;
                num &= ~(1 << 5);
                num <<= 1;
                num |= leftMostBit;
            }
        }

        Console.WriteLine(num);
    }
}