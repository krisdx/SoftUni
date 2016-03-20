using System;
using System.Linq;

class BunkerBuster
{
    static void Main()
    {
        int[] rowAndColuumnLengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = rowAndColuumnLengths[0];
        int cols = rowAndColuumnLengths[1];

        int[][] matrix = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }

        string command = Console.ReadLine();
        while (command != "cease fire!")
        {
            string[] commandDetails = command.Split();
            int bombRow = int.Parse(commandDetails[0]);
            int bombCol = int.Parse(commandDetails[1]);
            char bombChar = char.Parse(commandDetails[2]);

            matrix = BombMatrix(matrix, bombRow, bombCol, bombChar);

            command = Console.ReadLine();
        }

        int bunkersDestroyed = GetDestroyedBunkersCount(matrix);
        double damageInpercent = ((double)bunkersDestroyed / (rows * cols)) * 100;

        Console.WriteLine("Destroyed bunkers: {0}", bunkersDestroyed);
        Console.WriteLine("Damage done: {0:F1} %", Math.Round(damageInpercent, 2));
    }

    static int[][] BombMatrix(int[][] matrix, int bombRow, int bombCol, char bombChar)
    {
        int bombPower = (int)bombChar;
        matrix[bombRow][bombCol] -= bombPower;

        double reducedDamage = Math.Ceiling(bombPower / 2.0);

        // Upper row
        if (bombRow - 1 >= 0)
        {
            // Upper row center cell
            if (bombCol >= 0 && bombCol <= matrix[bombRow - 1].Length - 1)
            {
                matrix[bombRow - 1][bombCol] -= (int)reducedDamage;
            }
            // Upper row left cell
            if (bombCol - 1 >= 0 && bombCol - 1 <= matrix[bombRow - 1].Length - 1)
            {
                matrix[bombRow - 1][bombCol - 1] -= (int)reducedDamage;
            }
            // Upper row right cell
            if (bombCol + 1 >= 0 && bombCol + 1 <= matrix[bombRow - 1].Length - 1)
            {
                matrix[bombRow - 1][bombCol + 1] -= (int)reducedDamage;
            }
        }

        // Current row
        if (bombCol - 1 >= 0 && bombCol - 1 <= matrix[bombRow].Length - 1) // Current row left cell
        {
            matrix[bombRow][bombCol - 1] -= (int)reducedDamage;
        }
        if (bombCol + 1 >= 0 && bombCol + 1 <= matrix[bombRow].Length - 1) // Current row right cell
        {
            matrix[bombRow][bombCol + 1] -= (int)reducedDamage;
        }

        // Lower row
        if (bombRow + 1 <= matrix.Length - 1)
        {
            // Lower row middle cell
            if (bombCol >= 0 && bombCol <= matrix[bombRow + 1].Length - 1)
            {
                matrix[bombRow + 1][bombCol] -= (int)reducedDamage;
            }
            // Lower row left cell
            if (bombCol - 1 >= 0 && bombCol - 1 <= matrix[bombRow + 1].Length - 1)
            {
                matrix[bombRow + 1][bombCol - 1] -= (int)reducedDamage;
            }
            // Lower row right cell
            if (bombCol + 1 >= 0 && bombCol + 1 <= matrix[bombRow + 1].Length - 1)
            {
                matrix[bombRow + 1][bombCol + 1] -= (int)reducedDamage;
            }
        }

        return matrix;
    }

    static int GetDestroyedBunkersCount(int[][] matrix)
    {
        int bunkersDestroyed = 0;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] <= 0)
                {
                    bunkersDestroyed++;
                }
            }
        }

        return bunkersDestroyed;
    }
}