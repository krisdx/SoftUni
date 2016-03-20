using System;

// Find online more information about ASCII (American Standard Code for Information Interchange) and write a program to prints the entire ASCII table of characters at the console (characters from 0 to 255). Note that some characters have a special purpose and will not be displayed as expected. You may skip them or display them differently. You may need to use for-loops.

class PrintTheASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        char ch = Convert.ToChar(0000);
        for (char i = Convert.ToChar(0000); i < 255; i++)
        {
            Console.Write(ch);
            ch++;
        }
        Console.WriteLine("\n");
    }
}