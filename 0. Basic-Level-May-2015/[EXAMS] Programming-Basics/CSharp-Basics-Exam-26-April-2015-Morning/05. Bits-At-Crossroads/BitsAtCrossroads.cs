using System;
using System.Linq;

class BitsAtCrossroads
{
    static void Main()
    {
        int boardSize = int.Parse(Console.ReadLine());

        int[] numbers = new int[boardSize];

        int crossRoadsCounter = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                break;
            }

            int[] crossRoadDetails = input.Split(' ').Select(int.Parse).ToArray();
            int numberIndex = crossRoadDetails[0];
            int bitPosition = crossRoadDetails[1];

            numbers[numberIndex] |= (1 << bitPosition);
            crossRoadsCounter++;

            // right up diagonal
            int startRow = numberIndex - 1;
            int startCol = bitPosition - 1;
            while (startRow >= 0 && startCol >= 0)
            {
                bool hasCross = ((numbers[startRow] >> startCol) & 1) == 1;
                if (hasCross)
                {
                    crossRoadsCounter++;
                }

                numbers[startRow] |= (1 << startCol);
                startRow--;
                startCol--;
            }

            //left up diagonal
            startRow = numberIndex - 1;
            startCol = bitPosition + 1;
            while (startRow >= 0 && startCol < boardSize)
            {
                bool hasCross = ((numbers[startRow] >> startCol) & 1) == 1;
                if (hasCross)
                {
                    crossRoadsCounter++;
                }

                numbers[startRow] |= (1 << startCol);
                startRow--;
                startCol++;
            }

            //down right diagonal
            startRow = numberIndex + 1;
            startCol = bitPosition - 1;
            while (startRow < boardSize && startCol >= 0)
            {
                bool hasCross = ((numbers[startRow] >> startCol) & 1) == 1;
                if (hasCross)
                {
                    crossRoadsCounter++;
                }

                numbers[startRow] |= (1 << startCol);
                startRow++;
                startCol--;
            }

            //down left diagonal
            startRow = numberIndex + 1;
            startCol = bitPosition + 1;
            while (startRow < boardSize && startCol < boardSize)
            {
                bool hasCross = ((numbers[startRow] >> startCol) & 1) == 1;
                if (hasCross)
                {
                    crossRoadsCounter++;
                }

                numbers[startRow] |= (1 << startCol);
                startRow++;
                startCol++;
            }
        }

        foreach (int num in numbers)
        {
            Console.WriteLine((uint)num); // uint cast !!!!  The last bit in int is for the sign. If we change the leftmost bit the result will be with minus
        }

        Console.WriteLine(crossRoadsCounter);
    }
}