using System;

// Write a program that enters 3 integers n, min and max (min ≤ max) and prints n random numbers in the range [min...max]. 

class RandomNumbersInGivenRange
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Please, enter min value = ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("Please, enter max value = ");
        int max = int.Parse(Console.ReadLine());

        while (min > max)
        {
            Console.WriteLine("\nThe min value is bigger then the max.\n");
            Console.Write("Please, re-enter the min value = ");
            min = int.Parse(Console.ReadLine());
            Console.Write("Please, re-enter the max value = ");
            max = int.Parse(Console.ReadLine());
        }

        Random random = new Random();
        Console.WriteLine("\n{0} random nubmers between {1} and {2}: \n", n, min, max);
        for (int i = 0; i < n; i++)
        {
            int randomNumbers = random.Next(min, max);
            Console.Write("{0} ", randomNumbers);
        }
        Console.WriteLine("\n");
    }
}