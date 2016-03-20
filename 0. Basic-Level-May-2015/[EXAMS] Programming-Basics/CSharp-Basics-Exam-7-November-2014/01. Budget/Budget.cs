using System;

class Budget
{
    static void Main() //-k.d
    {
        int budget = int.Parse(Console.ReadLine());
        int goesOutDays = int.Parse(Console.ReadLine());
        int homeTownWeekends = int.Parse(Console.ReadLine());

        int normalWeekednsInAMouth = 4 - homeTownWeekends;
        int daysInAMounth = 30 - ((normalWeekednsInAMouth * 2) + (homeTownWeekends * 2));
        
        int weekednsExpences = (normalWeekednsInAMouth * 2) * 20;
        int NormalDaysInAMounth = daysInAMounth - goesOutDays;
        int NormalDaysInAMounthExpences = NormalDaysInAMounth * 10;
        double goingOutExpenses = ((Math.Floor(0.03 * budget) + 10) * goesOutDays);

        int totalExpenses = (int)(goingOutExpenses + NormalDaysInAMounthExpences + weekednsExpences + 150);

        if (totalExpenses > budget)
        {
            Console.WriteLine("No, not enough {0}.", Math.Abs(totalExpenses - budget));
        }
        else if (totalExpenses < budget)
        {
            Console.WriteLine("Yes, leftover {0}.", Math.Abs(totalExpenses - budget));
        }
        else if (totalExpenses == budget)
        {
            Console.WriteLine("Exact Budget.");
        }
    }
}