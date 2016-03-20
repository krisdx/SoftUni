using System;

class CheatSheet
{
    static void Main() //-k.d
    {
        long rows = long.Parse(Console.ReadLine());
        long columns = long.Parse(Console.ReadLine());
        long verticalStart = long.Parse(Console.ReadLine());
        long horizontalStart = long.Parse(Console.ReadLine());

        long horizontalCounter = horizontalStart;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write(verticalStart * horizontalStart);
                horizontalStart++;
                Console.Write(" "); 
            }
            verticalStart++;
            horizontalStart = horizontalCounter;
            Console.WriteLine();
        }
    }
}