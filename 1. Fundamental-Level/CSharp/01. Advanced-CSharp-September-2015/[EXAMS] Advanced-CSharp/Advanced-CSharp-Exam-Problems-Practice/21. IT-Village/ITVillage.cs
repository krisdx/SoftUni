using System;
using System.Linq;
using System.Text;

class ITVillage
{
    static int row = 0;
    static int col = 0;
    static string direction = string.Empty;

    static void Main()
    {
        string[] input = Console.ReadLine().Trim().Split('|');
        char[][] gameBoard = new char[input.Length][];
        for (int i = 0; i < input.Length; i++)
        {
            gameBoard[i] = TrimWhiteSpaces(input[i].ToCharArray());
        }

        int[] initialRowAndCol = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        row = initialRowAndCol[0] - 1;
        col = initialRowAndCol[1] - 1;

        int[] diceNumbers = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        GetInitialDirection(gameBoard);

        int inns = 0;
        long coins = 50;
        for (int i = 0; i < diceNumbers.Length; i++)
        {
            int movesToMake = diceNumbers[i];
            for (int j = 0; j < movesToMake; j++)
            {
                if (direction == "right")
                {
                    col++;
                    if (col == gameBoard[row].Length - 1)
                    {
                        direction = "down";
                    }
                }
                else if (direction == "down")
                {
                    row++;
                    if (row == gameBoard.Length - 1)
                    {
                        direction = "left";
                    }
                }
                else if (direction == "left")
                {
                    col--;
                    if (col <= 0)
                    {
                        direction = "up";
                    }
                }
                else if (direction == "up")
                {
                    row--;
                    if (row <= 0)
                    {
                        direction = "right";
                    }
                }
            }

            coins += 20 * inns;

            // chech where've landed
            if (gameBoard[row][col] == 'P')
            {
                coins -= 5;
            }
            else if (gameBoard[row][col] == 'I')
            {
                if (coins > 100)
                {
                    coins -= 100;
                    inns++;
                    gameBoard[row][col] = '`';
                }
                else
                {
                    coins -= 10;
                }
            }
            else if (gameBoard[row][col] == 'F')
            {
                coins += 20;
            }
            else if (gameBoard[row][col] == 'S')
            {
                i += 2;
            }
            else if (gameBoard[row][col] == 'V')
            {
                coins *= 10;
            }
            else if (gameBoard[row][col] == 'N')
            {
                Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                return;
            }

            // check if we won of lose the game
            if (coins < 0)
            {
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
                return;
            }
            else
            {
                bool hasInnsleft = CheckForLeftInns(gameBoard);
                if (!hasInnsleft)
                {
                    Console.WriteLine("<p>You won! You own the village now! You have {0} coins!<p>", coins);
                    return;
                }
            }
        }

        Console.WriteLine("<p>You lost! No more moves! You have {0} coins!<p>", coins);
    }

    public static bool CheckForLeftInns(char[][] gameBoard)
    {
        foreach (var row in gameBoard)
        {
            foreach (var letter in row)
            {
                if (letter == 'I')
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static void GetInitialDirection(char[][] gameBoard)
    {
        if (row == 0 && col < gameBoard[row].Length - 1)
        {
            direction = "right";
        }
        else if (row < gameBoard.Length - 1 && col == gameBoard[row].Length - 1)
        {
            direction = "down";
        }
        else if (row == gameBoard.Length - 1 && col > 0)
        {
            direction = "left";
        }
        else if (row > 0 && col == 0)
        {
            direction = "up";
        }
    }

    public static char[] TrimWhiteSpaces(char[] row)
    {
        StringBuilder currentRow = new StringBuilder();
        for (int i = 0; i < row.Length; i++)
        {
            if (!char.IsWhiteSpace(row[i]))
            {
                currentRow.Append(row[i]);
            }
        }

        return currentRow.ToString().ToCharArray();
    }
}