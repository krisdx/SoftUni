using System;

// Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English). Print “not a digit” in case of invalid inut. Use a switch statement.

class DigitAsWord
{
    static void Main()
    {
        Console.Write("Please, enter a digit (0-9): ");
        int digit = int.Parse(Console.ReadLine());

        switch (digit) 
        {
            case 1:
                Console.WriteLine("\nOne.\n");
                break;
            case 2:
                Console.WriteLine("\nTwo.\n");
                break;
            case 3:
                Console.WriteLine("\nThree.\n");
                break;
            case 4:
                Console.WriteLine("\nFour.\n");
                break;
            case 5:
                Console.WriteLine("\nFive.\n");
                break;
            case 6:
                Console.WriteLine("\nSix.\n");
                break;
            case 7:
                Console.WriteLine("\nSeven.\n");
                break;
            case 8:
                Console.WriteLine("\nEigth.\n");
                break;
            case 9:
                Console.WriteLine("\nNine.\n");
                break;
            default:
                Console.WriteLine("\nNot a digit.\n");
                break;
        }
    }
}

