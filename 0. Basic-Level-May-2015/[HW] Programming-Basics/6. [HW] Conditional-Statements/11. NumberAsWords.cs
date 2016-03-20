using System;

// Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation. 

class NumberAsWords
{
    static void Main()
    {
        Console.WriteLine("Please, enter a number in the range [0…999]: ");
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        while (n < 0 && n > 999)
        {
            Console.WriteLine("Please, re-enter n = ");
            n = int.Parse(Console.ReadLine());
        }

        if (n == 0)
        {
            Console.WriteLine("\nZero.");
        }
        else
        {
            int nHundreds = (n / 100) % 10;
            int nTens = (n / 10) % 10;
            int nDigits = (n / 1) % 10;

            if (n > 0 && n < 11) //  Numbers from 0 - 10
            {
                if (n == 10) // if statement only for 10
                {
                    Console.WriteLine("\nten\n");
                }
                else // Numbers from 0 - 9
                {
                    Console.WriteLine();
                    Digits(nDigits);
                    Console.WriteLine("\n");
                }
            }
            else if (n > 10 && n <= 19) // Numbers from 11 - 19
            {
                Console.WriteLine();
                ElevenToTwenty(nDigits);
                Console.WriteLine("\n");
            }
            else if (n > 19 && n < 100) // Numbers from 20 - 99
            {
                Console.WriteLine();
                TwentyToNinetyNine(nTens, nHundreds);
                Digits(nDigits);
                Console.WriteLine("\n");
            }

            else if (n >= 100 && (nDigits != 0)) // 100 - 999 
            {
                if (nTens == 1 && (nDigits == 1 || nDigits == 2 || nDigits == 3 || nDigits == 4 || nDigits == 5 || nDigits == 6 || nDigits == 7 || nDigits == 8 || nDigits == 9)) //Numbers like: 518, 613, 911, 514
                {
                    Console.WriteLine();
                    Hundreds(nHundreds);
                    Tens(nTens, nDigits);
                    Console.WriteLine("\n");
                }
                else // Every other combination, like: 123, 815, 967, 487..
                {
                    Console.WriteLine();
                    Hundreds(nHundreds);
                    Tens(nTens, nDigits);
                    Digits(nDigits);
                    Console.WriteLine("\n");
                }
            }

            else if (nHundreds >= 1 && (nTens == 0 && nDigits == 0)) // For the whole hundreds (100, 200, ..)
            {
                Console.WriteLine();
                Hundreds(nHundreds);
                Console.WriteLine("\n");
            }

            else if ((nHundreds >= 1) && (nTens >= 1) && (nDigits == 0)) // Numbers like: 530, 120, 190, 270
            {
                Console.WriteLine();
                Hundreds(nHundreds);
                Tens(nTens, nHundreds);
                Console.WriteLine("\n");
            }
        }
    }

    private static void Hundreds(int nHundreds)
    {
        switch (nHundreds)
        {
            case 1:
                Console.Write("One ");
                break;
            case 2:
                Console.Write("Two ");
                break;
            case 3:
                Console.Write("Three ");
                break;
            case 4:
                Console.Write("Four ");
                break;
            case 5:
                Console.Write("Five ");
                break;
            case 6:
                Console.Write("Six ");
                break;
            case 7:
                Console.Write("Seven ");
                break;
            case 8:
                Console.Write("Eight ");
                break;
            case 9:
                Console.Write("Nine ");
                break;
        }
        Console.Write("hundred");
    }

    private static void TwentyToNinetyNine(int nTens, int nHundreds)
    {
        switch (nTens)
        {
            case 1:
                ElevenToTwenty(nHundreds);
                break;
            case 2:
                Console.Write("twenty ");
                break;
            case 3:
                Console.Write("thirty ");
                break;
            case 4:
                Console.Write("forty ");
                break;
            case 5:
                Console.Write("fifty ");
                break;
            case 6:
                Console.Write("sixty ");
                break;
            case 7:
                Console.Write("seventy ");
                break;
            case 8:
                Console.Write("eighty ");
                break;
            case 9:
                Console.Write("ninety ");
                break;
        }
    }

    private static void Tens(int nTens, int nHundreds)
    {
        if (nHundreds >= 1 && nTens == 0)
        {
            Console.Write(" and");
        }
        else
        {
            Console.Write(" and ");
        }
        switch (nTens)
        {
            case 1:
                ElevenToTwenty(nHundreds);
                break;
            case 2:
                Console.Write("twenty");
                break;
            case 3:
                Console.Write("thirty");
                break;
            case 4:
                Console.Write("forty");
                break;
            case 5:
                Console.Write("fifty");
                break;
            case 6:
                Console.Write("sixty");
                break;
            case 7:
                Console.Write("seventy");
                break;
            case 8:
                Console.Write("eighty");
                break;
            case 9:
                Console.Write("ninety");
                break;
        }
        Console.Write(" ");
    }

    private static void ElevenToTwenty(int nHundreds)
    {
        switch (nHundreds)
        {
            case 1:
                Console.Write("eleven");
                break;
            case 2:
                Console.Write("twelve");
                break;
            case 3:
                Console.Write("thirteen");
                break;
            case 4:
                Console.Write("fourteen");
                break;
            case 5:
                Console.Write("fifteen");
                break;
            case 6:
                Console.Write("sixteen");
                break;
            case 7:
                Console.Write("seventeen");
                break;
            case 8:
                Console.Write("eighteen");
                break;
            case 9:
                Console.Write("nineteen");
                break;
        }
    }

    private static void Digits(int nDigits)
    {
        switch (nDigits)
        {
            case 1:
                Console.Write("one");
                break;
            case 2:
                Console.Write("two");
                break;
            case 3:
                Console.Write("three");
                break;
            case 4:
                Console.Write("four");
                break;
            case 5:
                Console.Write("five");
                break;
            case 6:
                Console.Write("six");
                break;
            case 7:
                Console.Write("seven");
                break;
            case 8:
                Console.Write("eight");
                break;
            case 9:
                Console.Write("nine");
                break;
            case 10:
                Console.Write("Ten.");
                break;
        }
    }
}