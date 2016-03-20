using System;
using System.Linq;

// Working with multidimensional arrays can be (and should be) fun. Let's make a game out of it.

// You receive the layout of a board from the console. Assume it will always have 4 rows which you'll get as strings, each on a separate line. Each character in the strings will represent a cell on the board. Note that the strings may be of different length.

// You are the player and start at the top-left corner (that would be position [0, 0] on the board). On the fifth line of input you'll receive a string with movement commands which tell you where to go next, it will contain only these four characters – '>' (move right), '<' (move left), '^' (move up) and 'v' (move down). 

// You need to keep track of two types of events – collecting coins (represented by the symbol '$', of course) and hitting the walls of the board (when the player tries to move off the board to invalid coordinates). When all moves are over, print the amount of money collected and the number of walls hit.

class CollectTheCoins
{
    static void Main()
    {
        char[][] matrix = new char[4][];
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = Console.ReadLine().ToCharArray();
        }

        int cointsCollected = 0;
        int wallsHit = 0;

        string commands = Console.ReadLine();

        int row = 0;
        int col = 0;
        for (int index = 0; index < commands.Length; index++)
        {
            Move(commands, ref row, ref col, index);

            if ((row < 0 || row >= matrix[row].Length) ||
                (col < 0 || col >= matrix[row].Length))
            {
                wallsHit++;
                GoBack(commands, ref row, ref col, index);
                continue;
            }

            if (matrix[row][col] == '$')
            {
                cointsCollected++;       
            }
        }

        Console.WriteLine("\nCoints collected: {0}", cointsCollected);
        Console.WriteLine("Walls hit: {0}\n", wallsHit);
    }

    private static void Move(string commands, ref int row, ref int col, int index)
    {
        switch (commands[index])
        {
            case 'V': row++; break;
            case '^': row--; break;
            case '<': col--; break;
            case '>': col++; break;
        }
    }

    private static void GoBack(string commands, ref int row, ref int col, int index)
    {
        switch (commands[index])
        {
            case 'V': row--; break;
            case '^': row++; break;
            case '<': col++; break;
            case '>': col--; break;
        }
    }
}