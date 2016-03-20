using System;

// Write a program to generate the following matrix of palindromes of 3 letters with r rows and c columns.

class MatrixOfPalindromes
{
    static void Main()
    {
        Console.Write("Please, enter rows = ");
        int row = int.Parse(Console.ReadLine());

        Console.Write("Please, enter columns = ");
        int col = int.Parse(Console.ReadLine());

        char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        Console.WriteLine("\nResult:\n");

        for (int r = 0; r <= row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                Console.Write("{0}{1}{0} ", alphabet[r], alphabet[c+r]);

            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
