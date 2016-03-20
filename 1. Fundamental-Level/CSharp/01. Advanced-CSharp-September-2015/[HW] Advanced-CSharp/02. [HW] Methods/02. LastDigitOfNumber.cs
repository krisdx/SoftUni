using System;

// Write a method that returns the last digit of a given integer as an English word. Test the method with different input values. Ensure you name the method properly.

class LastDigitOfNumber
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());

        string lastDigitAsWord = GetLastDigitAsWord(num);
        Console.WriteLine("The last digit is: {0}", lastDigitAsWord);
    }

    private static string GetLastDigitAsWord(int num)
    {
        int lastDigit = num % 10;

        string digitAsWord = string.Empty;
        switch (lastDigit)
        {
            case 0: digitAsWord = "Zero."; break;
            case 1: digitAsWord = "One."; break;
            case 2: digitAsWord = "Two."; break;
            case 3: digitAsWord = "Three."; break;
            case 4: digitAsWord = "Four."; break;
            case 5: digitAsWord = "Five."; break;
            case 6: digitAsWord = "Six."; break;
            case 7: digitAsWord = "Seven."; break;
            case 8: digitAsWord = "Eight."; break;
            case 9: digitAsWord = "Nine."; break;
            default: digitAsWord = "Not a digit."; break;
        }

        return digitAsWord;
    }
}