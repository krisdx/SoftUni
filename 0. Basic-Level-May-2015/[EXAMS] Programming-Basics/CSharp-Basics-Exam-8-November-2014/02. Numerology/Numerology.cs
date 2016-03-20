using System;

class Numerology
{
    static void Main() //-k.d
    {
        string input = Console.ReadLine();
        string[] inputArray = input.Split('.', ' ');

        int day = int.Parse(inputArray[0]);
        int month = int.Parse(inputArray[1]);
        int year = int.Parse(inputArray[2]);
        string username = inputArray[3];

        long dateProduct = day * month * year;
        if (month % 2 == 1)
        {
            dateProduct *= dateProduct;
        }

        for (int i = 0; i < username.Length; i++)
        {
            char currentLetter = username[i];

            if (currentLetter == '0' || currentLetter == '1' || currentLetter == '2' || currentLetter == '3' || currentLetter == '4' || currentLetter == '5' || currentLetter == '6' || currentLetter == '7' || currentLetter == '8' || currentLetter == '9')
            {
                int number = GetNumberFromChar(currentLetter);
                dateProduct += number;
            }
            else
            {
                if (char.IsLower(currentLetter))
                {
                    currentLetter = (char)(currentLetter - ('a' - 1));
                    dateProduct += currentLetter;
                }
                else
                {
                    currentLetter = (char)(currentLetter - ('A' - 1));
                    currentLetter = (char)(currentLetter * 2);
                    dateProduct += currentLetter;
                }
            }
        }

        long digitSum = 0;
        while (dateProduct > 13)
        {
            while (dateProduct > 0)
            {
                digitSum += dateProduct % 10;
                dateProduct /= 10;
            }
            dateProduct = digitSum;
            digitSum = 0;
        }
        Console.WriteLine(dateProduct);
    }

    static int GetNumberFromChar(char stringDigit)
    {
        int intDigit = 0;
        switch (stringDigit)
        {
            case '0': intDigit = 0; break;
            case '1': intDigit = 1; break;
            case '2': intDigit = 2; break;
            case '3': intDigit = 3; break;
            case '4': intDigit = 4; break;
            case '5': intDigit = 5; break;
            case '6': intDigit = 6; break;
            case '7': intDigit = 7; break;
            case '8': intDigit = 8; break;
            case '9': intDigit = 9; break;
        }
        return intDigit;
    }
}