using System;

// Using loops write a program that converts a hexadecimal integer number to its decimal form. The input is entered as string. The output should be a variable of type long. Do not use the built-in .NET functionality. 

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        Console.WriteLine("Please, enter a hexadecimal integer number: ");
        string inputHex = Console.ReadLine();

        bool areCapitalLetters = true;
        string[] inputArray = new string[inputHex.Length];
        for (int i = 0; i < inputArray.Length; i++)
        {
            inputArray[i] = Convert.ToString(inputHex[i]);
            if (inputArray[i] == "a" || inputArray[i] == "b" || inputArray[i] == "c" || inputArray[i] == "d" || inputArray[i] == "e" || inputArray[i] == "f")
            {
                areCapitalLetters = false;
                break;
            }
        }

        if (areCapitalLetters == false)
        {
            Console.WriteLine("\nSorry, the letters must be capital :( \n");
        }
        else
        {
            Array.Reverse(inputArray);
            int operatingNumber;
            double decimalNumber = 0;
            for (int k = 0; k < inputHex.Length; k++)
            {
                operatingNumber = HexToInt(inputArray, k);
                decimalNumber += operatingNumber * Math.Pow(16, k);
            }
            decimalNumber = (long)decimalNumber;
            Console.WriteLine("\nDecimal representation: {0}\n", decimalNumber);
        }
    }

    private static int HexToInt(string[] inputArray, int k)
    {
        int numberToMultiply = 0;
        switch (inputArray[k])
        {
            case "0":
                numberToMultiply = 0;
                break;
            case "1":
                numberToMultiply = 1;
                break;
            case "2":
                numberToMultiply = 2;
                break;
            case "3":
                numberToMultiply = 3;
                break;
            case "4":
                numberToMultiply = 4;
                break;
            case "5":
                numberToMultiply = 5;
                break;
            case "6":
                numberToMultiply = 6;
                break;
            case "7":
                numberToMultiply = 7;
                break;
            case "8":
                numberToMultiply = 8;
                break;
            case "9":
                numberToMultiply = 9;
                break;
            case "A":
                numberToMultiply = 10;
                break;
            case "B":
                numberToMultiply = 11;
                break;
            case "C":
                numberToMultiply = 12;
                break;
            case "D":
                numberToMultiply = 13;
                break;
            case "E":
                numberToMultiply = 14;
                break;
            case "F":
                numberToMultiply = 15;
                break;
        }
        return numberToMultiply;
    }
}