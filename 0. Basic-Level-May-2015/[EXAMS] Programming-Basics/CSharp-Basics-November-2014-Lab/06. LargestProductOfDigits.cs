using System;

class LargestProductOfDigits //-k.d
{
    static void Main()
    {
        string input = Console.ReadLine();

        int[] numbers = new int[input.Length];
        for (int num = 0; num < numbers.Length; num++)
        {
            numbers[num] = int.Parse(Convert.ToString(input[num]));
        }

        int maxProduct = int.MinValue;
        for (int i = 0; i < numbers.Length - 5; i++)
        {
            int currentProduct = numbers[i] * numbers[i + 1] * numbers[i + 2] * numbers[i + 3] * numbers[i + 4] * numbers[i + 5];
            if (currentProduct > maxProduct)
            {
                maxProduct = currentProduct;
            }
        }

        Console.WriteLine(maxProduct);
    }
}