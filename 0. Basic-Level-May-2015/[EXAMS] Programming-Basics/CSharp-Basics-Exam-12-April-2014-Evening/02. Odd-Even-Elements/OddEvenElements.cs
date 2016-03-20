using System;

class OddEvenElements //-k.d
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] stringNumbers = input.Split(' ');
        decimal[] numbers = new decimal[stringNumbers.Length];
        if (input == "")
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
        }
        else
        {
            decimal oddSum = 0;
            decimal oddMin = decimal.MinValue;
            decimal oddMax = decimal.MinValue;
            decimal evenSum = 0;
            decimal evenMin = decimal.MinValue;
            decimal evenMax = decimal.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = decimal.Parse(stringNumbers[i]);

                if (i == 0 || i % 2 == 0)
                {
                    oddSum += numbers[i];
                    if (numbers[i] < oddMin || oddMin == decimal.MinValue)
                    {
                        oddMin = numbers[i];
                    }
                    if (numbers[i] > oddMax)
                    {
                        oddMax = numbers[i];
                    }
                }
                else if (i == 1 || i % 2 == 1)
                {
                    evenSum += numbers[i];
                    if (numbers[i] < evenMin || evenMin == decimal.MinValue)
                    {
                        evenMin = numbers[i];
                    }
                    if (numbers[i] > evenMax)
                    {
                        evenMax = numbers[i];
                    }
                }
            }
            if (numbers.Length <= 1)
            {
                Console.WriteLine("OddSum={0:0.##}, OddMin={1:0.##}, OddMax={2:0.##}, EvenSum=No, EvenMin=No, EvenMax=No", oddSum, oddMin, oddMax);
            }
            else
            {
                Console.WriteLine("OddSum={0:0.##}, OddMin={1:0.##}, OddMax={2:0.##}, EvenSum={3:0.##}, EvenMin={4:0.##}, EvenMax={5:0.##}", oddSum, oddMin, oddMax, evenSum, evenMin, evenMax);
            }
        }
    }
}