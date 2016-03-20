using System;
using System.Linq;

class BitPaths
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        int[] board = new int[8];
        for (int i = 0; i < count; i++)
        {
            string inputPaths = Console.ReadLine();
            int[] path = inputPaths.Split(',').Select(int.Parse).ToArray();

            int position = 3 - path[0];
            for (int j = 0; j < path.Length; j++)
            {
                int mask = (1 << position);
                //Console.WriteLine(Convert.ToString(board[j], 2).PadLeft(4, '0'));
                //Console.WriteLine(Convert.ToString(mask, 2).PadLeft(4, '0'));
                board[j] ^= mask;
                // Console.WriteLine(Convert.ToString(board[j], 2).PadLeft(4, '0'));
                if (j == 7)
                {
                    break;
                }
                position -= path[j + 1];
            }
        }

        int sum = board.Sum();
        Console.WriteLine(Convert.ToString(sum, 2));
        Console.WriteLine("{0:X}", sum);
    }
}