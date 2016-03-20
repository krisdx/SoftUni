using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsMain
{
    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subArray = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subArray));

        var allArray = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allArray));

        var emptyArray = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyArray));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));

        // Console.WriteLine(ExtractEnding("Hi", 100));

        bool isPrime = CheckPrime(23);
        Console.WriteLine(isPrime ? "The number 23 is prime." : "The number 23 is not prime.");

        isPrime = CheckPrime(33);
        Console.WriteLine(isPrime ? "The number 33 is prime." : "The number 33 is not prime.");

        List<Exam> peterExams = new List<Exam>
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);

        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }

    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        var result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new InvalidOperationException("The count is bigger than the string's length.");
        }

        StringBuilder result = new StringBuilder();

        int startIndex = str.Length - count;
        for (int i = startIndex; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        int maxDivisor = (int)Math.Sqrt(number);
        for (int divisor = 2; divisor <= maxDivisor; divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }
}