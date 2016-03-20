using System;

// Write a program which reads a string matrix from the console and performs certain operations with its elements. User input is provided like in the problem above – first you read the dimensions and then the data. Remember, you are not required to do this step first, you may add this functionality later.  

// Your program should then receive commands in format: "swap x1 y1 x2 y2" where x1, x2, y1, y2 are coordinates in the matrix. In order for a command to be valid, it should start with the "swap" keyword along with four valid coordinates (no more, no less). You should swap the values at the given coordinates (cell [x1, y1] with cell [x2, y2]) and print the matrix at each step (thus you'll be able to check if the operation was performed correctly). 

// If the command is not valid (doesn't contain the keyword "swap", has fewer or more coordinates entered or the given coordinates do not exist), print "Invalid input!" and move on to the next command. Your program should finish when the string "END" is entered.

class MatrixShuffling
{
    static string dashes = new string('-', 10); // for clearity

    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        string[,] matrix = new string[rows, cols];
        FillMatrix(rows, cols, matrix);

        string command = Console.ReadLine().Trim();
        while (command != "END")
        {
            string[] commandDetalis = command.Split();
            bool isCommandCorrect = IsCommandCorrect(commandDetalis, rows, cols);
            if (!isCommandCorrect)
            {
                Console.WriteLine(dashes);
                Console.WriteLine("Invalid input!");
                Console.WriteLine(dashes + "\n");

                command = Console.ReadLine().Trim();
                continue;
            }

            int firstNumRow = int.Parse(commandDetalis[1]);
            int firstNumCol = int.Parse(commandDetalis[2]);
            int secondNumRow = int.Parse(commandDetalis[3]);
            int secondNumCol = int.Parse(commandDetalis[4]);

            // swaping
            string swapValue = matrix[firstNumRow, firstNumCol];
            matrix[firstNumRow, firstNumCol] = matrix[secondNumRow, secondNumCol];
            matrix[secondNumRow, secondNumCol] = swapValue;

            // printing
            Console.WriteLine(dashes);
            Console.WriteLine("(After swaping \"{0}\" and \"{1}\"):\n", matrix[secondNumRow, secondNumCol], matrix[firstNumRow, firstNumCol]);
            PrintMatrix(matrix);
            Console.WriteLine(dashes + "\n");

            command = Console.ReadLine().Trim();
        }
    }

    private static void FillMatrix(int rows, int cols, string[,] matrix)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = Console.ReadLine();
            }
        }
        Console.WriteLine();
    }

    private static bool IsCommandCorrect(string[] commandDetalis, int matrixRows, int matrixCols)
    {
        bool hasCorrectLength = commandDetalis.Length == 5;
        bool hasTheWordSwap = commandDetalis[0] == "swap";
        int n;
        bool isFirstNumRowValid = int.TryParse(commandDetalis[1], out n) && n < matrixRows;
        bool isFirstNumColValid = int.TryParse(commandDetalis[1], out n) && n < matrixCols;
        bool isSecondNumRowValid = int.TryParse(commandDetalis[1], out n) && n < matrixRows;
        bool isSecondNumColValid = int.TryParse(commandDetalis[1], out n) && n < matrixCols;

        if (hasCorrectLength && hasTheWordSwap &&
            isFirstNumRowValid && isFirstNumColValid &&
            isSecondNumRowValid && isSecondNumColValid)
        {
            return true;
        }

        return false;
    }

    private static void PrintMatrix(string[,] matrix)
    {
       
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                Console.Write(matrix[row, col] + "  ");
            }
            Console.WriteLine();
        }
    }
}