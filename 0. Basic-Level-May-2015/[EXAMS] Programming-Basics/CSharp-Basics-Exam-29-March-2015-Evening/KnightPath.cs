using System;

class KnightPath
{
    static void Main() //-k.d
    {
        int[] numbers = new int[8];

        numbers[0] |= 1; // starting position of the king

        int row = 0;
        int col = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "stop")
            {
                break;
            }
            string[] directionDetails = input.Split(' ');
            string firstDirection = directionDetails[0];
            string secondDirection = directionDetails[1];

            // checking if after we mack the move it is out of the board
            bool isOutsideOfBoard = CheckBoard(row, col, firstDirection, secondDirection); 
            if (isOutsideOfBoard)
            {
                continue;
            }
            else
            {
                //First direction
                if (firstDirection == "left")
                {
                    col += 2;
                }
                else if (firstDirection == "right")
                {
                    col -= 2;
                }
                else if (firstDirection == "up")
                {
                    row -= 2;
                }
                else if (firstDirection == "down")
                {
                    row += 2;
                }

                //Second direction
                if (secondDirection == "left")
                {
                    col++;
                }
                else if (secondDirection == "right")
                {
                    col--;
                }
                else if (secondDirection == "up")
                {
                    row--;
                }
                else if (secondDirection == "down")
                {
                    row++;
                }

            }

            numbers[row] ^= (1 << col);
        }

        bool wholeBoardEmpty = true; // WHOLE board
        for (int num = 0; num < numbers.Length; num++)
        {
            if (numbers[num] != 0)
            {
                wholeBoardEmpty = false;
            }
        }
        if (wholeBoardEmpty)
        {
            Console.WriteLine("[Board is empty]");
        }
        else
        {
            foreach (int num in numbers)
            {
                if (num == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(num);
                }
            }
        }
    }

    private static bool CheckBoard(int row, int col, string firstDirection, string secondDirection)
    {
        bool isOutside = false;

        //First direction
        if (firstDirection == "left")
        {
            col += 2;
        }
        else if (firstDirection == "right")
        {
            col -= 2;
        }
        else if (firstDirection == "up")
        {
            row -= 2;
        }
        else if (firstDirection == "down")
        {
            row += 2;
        }

        //Second direction
        if (secondDirection == "left")
        {
            col++;
        }
        else if (secondDirection == "right")
        {
            col--;
        }
        else if (secondDirection == "up")
        {
            row--;
        }
        else if (secondDirection == "down")
        {
            row++;
        }

        bool isOutsideUp = row < 0;
        bool isOutsideDown = row > 7;
        bool isOutsideLeft = col > 7;
        bool isOutsideRight = col < 0;
        if (isOutsideUp || isOutsideDown || isOutsideRight || isOutsideLeft)
        {
            isOutside = true;
        }

        return isOutside;
    }
}