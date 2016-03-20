using System;

class DreamItem //-k.d
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] salaryDetails = input.Split('\\');

        string month = salaryDetails[0];
        int workDays = GetDays(month);
        workDays -= 10; // holidays
        decimal moneyPerHour = decimal.Parse(salaryDetails[1]);
        decimal hoursWorkPerDay = decimal.Parse(salaryDetails[2]);
        decimal itemPrice = decimal.Parse(salaryDetails[3]);

        decimal totalSalary = workDays * moneyPerHour * hoursWorkPerDay;
        if (totalSalary > 700)
        {
            totalSalary = totalSalary + (totalSalary * 0.1m);
        }

        bool canAffortItem = totalSalary - itemPrice >= 0;
        if (canAffortItem)
        {
            Console.WriteLine("Money left = {0:F2} leva.", totalSalary - itemPrice);
        }
        else
        {
            Console.WriteLine("Not enough money. {0:F2} leva needed.", Math.Abs(totalSalary - itemPrice));
        }
    }

    private static int GetDays(string month)
    {
        int days = 0;

        switch (month)
        {
            case "Jan": days = 31; break;
            case "Feb": days = 28; break;
            case "March": days = 31; break; //The input data was "March" (not "Mar" as described in constraints)
            case "Apr": days = 30; break;
            case "May": days = 31; break;
            case "June": days = 30; break;
            case "July": days = 31; break;
            case "Aug": days = 31; break;
            case "Sept": days = 30; break;
            case "Oct": days = 31; break;
            case "Nov": days = 30; break;
            case "Dec": days = 31; break;
        }
        return days;
    }
}