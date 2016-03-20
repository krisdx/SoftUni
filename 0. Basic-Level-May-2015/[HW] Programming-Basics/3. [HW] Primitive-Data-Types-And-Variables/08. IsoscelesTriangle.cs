using System;

// Write a program that prints an isosceles triangle of 9 copyright symbols ©, 

class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        char copyRight = '\u00A9';

        Console.WriteLine("   {0}\n  {0} {0}\n {0}   {0}\n{0} {0} {0} {0}", copyRight);

        Console.WriteLine();

        // Second way:

        //Console.WriteLine("   " + '©');
        //Console.WriteLine("  " + '©' +" " + '©' );
        //Console.WriteLine(" " + '©' + "   " + '©');
        //Console.WriteLine('©' +" " + '©' + " " + '©' + " " + '©');
    }
}