﻿using System;

// Declare a character variable and assign it with the symbol that has Unicode code 42 (decimal) using the '\u00XX' syntax, and then print it. Hint: first, use the Windows Calculator to find the hexadecimal representation of 42. The output should be “*”.

class UnicodeCharacter
{
    static void Main()
    {
        char chr = '\u002A';
        Console.WriteLine("The 42th Unicode char is: {0}\n", chr);
    }
}