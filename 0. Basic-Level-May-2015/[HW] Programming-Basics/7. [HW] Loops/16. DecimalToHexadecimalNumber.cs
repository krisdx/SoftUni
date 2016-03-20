using System;

// Using loops write a program that converts an integer number to its hexadecimal representation. The input is entered as long. The output should be a variable of type string. Do not use the built-in .NET functionality. 

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        Console.Write("Please, enter an integer: ");
        long inputDecimal = long.Parse(Console.ReadLine());

        string[] reminder = new string[64];
        for (int i = 0; i < 32; i++)
        {
            reminder[i] = Convert.ToString(inputDecimal % 16);

            if (reminder[i] == "10")
            {
                reminder[i] = "A";
            }
            else if ((reminder[i] == "11"))
            {
                reminder[i] = "B";
            }
            else if ((reminder[i] == "12"))
            {
                reminder[i] = "C";
            }
            else if ((reminder[i] == "13"))
            {
                reminder[i] = "D";
            }
            else if ((reminder[i] == "14"))
            {
                reminder[i] = "E";
            }
            else if ((reminder[i] == "15"))
            {
                reminder[i] = "F";
            }

            inputDecimal = inputDecimal / 16;

            if (inputDecimal == 0)
            {
                break;
            }
        }

        Array.Reverse(reminder);
        Console.WriteLine("\nHexadecimal representanion: ");
        for (int i = 0; i < reminder.Length; i++)
        {
            Console.Write("{0}", reminder[i]);
        }

        Console.WriteLine("\n");
    }
}