using System;

class OddEvenCounter //-k.d
{
    private static void Main()
    {
        long setsCount = long.Parse(Console.ReadLine());
        long numbersInEachSet = long.Parse(Console.ReadLine());
        string oddOrEven = Console.ReadLine();

        long currentOddCounter = 0;
        long currnetEvenCounter = 0;
        long maxOddNumbers = int.MinValue;
        long maxEvenNumbers = int.MinValue;
        long oddSetCounter = 0;
        long evenSetCounter = 0;
        for (int i = 1; i <= setsCount; i++)
        {
            int[] numbers = new int[numbersInEachSet];
            for (int num = 0; num < numbers.Length; num++)
            {
                numbers[num] = int.Parse(Console.ReadLine());
            }

            for (int index = 0; index < numbers.Length; index++)
            {
                if (numbers[index] % 2 == 1) // odd
                {
                    currentOddCounter++;
                }
                else // even
                {
                    currnetEvenCounter++;
                }
            }
            if (currentOddCounter > maxOddNumbers)
            {
                maxOddNumbers = currentOddCounter;
                oddSetCounter = i;
            }
            if (currnetEvenCounter > maxEvenNumbers)
            {
                maxEvenNumbers = currnetEvenCounter;
                evenSetCounter = i;
            }
            currentOddCounter = 0;
            currnetEvenCounter = 0;
        }

        if ((oddOrEven == "odd" && maxOddNumbers <= 0) || (oddOrEven == "even" && maxEvenNumbers <= 0))
        {
            Console.WriteLine("No");
            return;
        }
        else if (oddOrEven == "odd")
        {
            string ordinalRepresentation = GetOrdinalValue(oddSetCounter);
            Console.WriteLine("{0} set has the most {1} numbers: {2}", ordinalRepresentation, oddOrEven, maxOddNumbers);
        }
        else
        {
            string ordinalRepresentation = GetOrdinalValue(evenSetCounter);
            Console.WriteLine("{0} set has the most {1} numbers: {2}", ordinalRepresentation, oddOrEven, maxEvenNumbers);
        }
    }

    static string GetOrdinalValue(long setNumber)
    {
        string ordinalValue = "";
        switch (setNumber)
        {
            case 1: ordinalValue = "First"; break;
            case 2: ordinalValue = "Second"; break;
            case 3: ordinalValue = "Third"; break;
            case 4: ordinalValue = "Fourth"; break;
            case 5: ordinalValue = "Fifth"; break;
            case 6: ordinalValue = "Sixth"; break;
            case 7: ordinalValue = "Seventh"; break;
            case 8: ordinalValue = "Eighth"; break;
            case 9: ordinalValue = "Ninth"; break;
            case 10: ordinalValue = "Tenth"; break;
        }
        return ordinalValue;
    }
}