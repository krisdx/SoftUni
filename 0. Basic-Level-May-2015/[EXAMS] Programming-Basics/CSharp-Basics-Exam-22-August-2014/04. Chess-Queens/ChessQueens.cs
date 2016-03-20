using System;

class ChessQueens
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int diff = 1 + int.Parse(Console.ReadLine());

        char[] letters = new char[n];
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i] = (char)('a' + i);
        }

        bool solutionFound = false;
        for (int x1 = 0; x1 < n; x1++)
        {
            for (int y1 = 0; y1 < n; y1++)
            {
                for (int x2 = 0; x2 < n; x2++)
                {
                    for (int y2 = 0; y2 < n; y2++)
                    {
                        bool xMeet = x1 == x2 && Math.Abs(y1 - y2) == diff;
                        bool yMeet = y1 == y2 && Math.Abs(x1 - x2) == diff;
                        bool diagonalMeet = Math.Abs(y1 - y2) == diff && Math.Abs(x1 - x2) == diff;

                        if (xMeet || yMeet || diagonalMeet)
                        {
                            Console.WriteLine("{0}{1} - {2}{3}", letters[x1], y1 + 1, letters[x2], y2 + 1);
                            solutionFound = true;
                        }
                    }
                }
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No valid positions");
        }
    }
}