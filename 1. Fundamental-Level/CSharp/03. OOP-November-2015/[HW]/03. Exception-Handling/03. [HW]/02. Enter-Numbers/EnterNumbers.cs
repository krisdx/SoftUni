using System;
using System.Collections.Generic;

public class EnterNumbers
{
    private static List<int> numbers = new List<int>();

    public static void Main()
    {
        try
        {
            Console.Write("Enter start range: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Enter end range: ");
            int end = int.Parse(Console.ReadLine());

            if (start < 1 || end > 100)
            {
                throw new ArgumentOutOfRangeException("The start and end numbers must be in range [0..100]");
            }

            // read
            for (int i = 0; i < 10; i++)
            {
                ReadNumber(start, end);
            }

            // print
            Console.WriteLine("\nNumbers: \n{0}", string.Join(", ", numbers));
        }
        catch (FormatException)
        {
            throw new FormatException("Invalid number.");
        }
        catch (OverflowException)
        {
            throw new OverflowException("Number is too large.");
        }
    }

    public static void ReadNumber(int start, int end)
    {
        int num = 0;
        try
        {
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());

            while (num < start || num > end)
            {
                Console.Write("Try again: ");
                num = int.Parse(Console.ReadLine());
            }
        }
        catch (FormatException)
        {
            num = HandleExeption(num);
        }
        catch (OverflowException)
        {
            num = HandleExeption(num);
        }
        finally
        {
            numbers.Add(num);
        }
    }

    private static int HandleExeption(int num)
    {
        Console.Write("Try again: ");
        bool isSuccessful = int.TryParse(Console.ReadLine(), out num);
        while (!isSuccessful)
        {
            Console.Write("Try again: ");
            isSuccessful = int.TryParse(Console.ReadLine(), out num);
        }

        return num;
    }
}