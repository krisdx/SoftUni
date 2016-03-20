using System;

class DailyCalorieIntake
{
    static void Main()
    {
        decimal weight = decimal.Parse(Console.ReadLine()) / 2.2m;
        decimal height = decimal.Parse(Console.ReadLine()) * 2.54m;
        decimal age = decimal.Parse(Console.ReadLine());
        char gender = char.Parse(Console.ReadLine());
        decimal workoutsPerWeek = decimal.Parse(Console.ReadLine());

        decimal BMR;
        if (gender == 'm')
        {
            BMR = 66.5m + (13.75m * weight) + (5.003m * height) - (6.755m * age);
        }
        else
        {
            BMR = 655m + (9.563m * weight) + (1.850m * height) - (4.676m * age);
        }

        decimal DCI = GetDCI(BMR, workoutsPerWeek);
        Console.WriteLine(Math.Floor(DCI));
    }

    private static decimal GetDCI(decimal BMR, decimal workoutsPerWeek)
    {
        if (workoutsPerWeek <= 0)
        {
            return BMR * 1.2m;
        }
        else if (workoutsPerWeek >= 1 &&
                 workoutsPerWeek <= 3)
        {
            return BMR * 1.375m;
        }
        else if (workoutsPerWeek >= 4 &&
                 workoutsPerWeek <= 6)
        {
            return BMR * 1.55m;
        }
        else if (workoutsPerWeek >= 7 &&
                 workoutsPerWeek <= 9)
        {
            return BMR * 1.725m;
        }
        else //if (workoutsPerWeek > 9)
        {
            return BMR * 1.9m;
        }
    }
}