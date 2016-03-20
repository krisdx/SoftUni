using System;
using System.Text.RegularExpressions;

public class PerfectGirlfriend
{
    public static void Main()
    {
        int perfectGirlsCount = 0;

        string date = Console.ReadLine();
        while (true)
        {
            if (date == "Enough dates!")
            {
                break;
            }

            string[] dateDetails = date.Split('\\');
            string dayOfWeek = dateDetails[0];
            string telephoneNumber = dateDetails[1];
            string braSize = dateDetails[2];
            string girlName = dateDetails[3];

            int totalSum = 0;
            totalSum += GetValueFromDayOfWeek(dayOfWeek);

            totalSum += SumDigits(telephoneNumber);

            totalSum += GetBraValue(braSize);

            totalSum -= CalculateName(girlName);

            if (totalSum >= 6000)
            {
                Console.WriteLine("{0} is perfect for you.", girlName);
                perfectGirlsCount++;
            }
            else
            {
                Console.WriteLine("Keep searching, {0} is not for you.", girlName);
            }

            date = Console.ReadLine();
        }

        Console.WriteLine(perfectGirlsCount);
    }

    private static int CalculateName(string girlName)
    {
        char firstLetter = girlName[0];

        return firstLetter * girlName.Length;
    }

    private static int GetBraValue(string braSize)
    {
        Regex regex = new Regex(@"(\d+)([A-Z])");
        Match match = regex.Match(braSize);

        int num = int.Parse(match.Groups[1].Value);
        char letter = char.Parse(match.Groups[2].Value);

        return num * letter;
    }

    private static int SumDigits(string telephoneNumber)
    {
        int sum = 0;
        for (int i = 0; i < telephoneNumber.Length; i++)
        {
            sum += int.Parse(telephoneNumber[i].ToString());
        }

        return sum;
    }

    private static int GetValueFromDayOfWeek(string dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case "Monday":
                return 1;
            case "Tuesday":
                return 2;
            case "Wednesday":
                return 3;
            case "Thursday":
                return 4;
            case "Friday":
                return 5;
            case "Saturday":
                return 6;
            case "Sunday":
                return 7;
            default:
                return -1;
        }
    }
}