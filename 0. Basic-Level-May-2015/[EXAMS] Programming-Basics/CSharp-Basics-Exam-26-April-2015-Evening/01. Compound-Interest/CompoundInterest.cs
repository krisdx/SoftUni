using System;

class CompoundInterest
{
    static void Main()//-k.d
    {
        double priceOfTV = double.Parse(Console.ReadLine());
        double YearsToRetunrLoan = double.Parse(Console.ReadLine());
        double yearlyInterestRate = double.Parse(Console.ReadLine());
        double yearlyInterestFriendLoan = double.Parse(Console.ReadLine());

        double bankLoan = Math.Round(priceOfTV * Math.Pow((1 + yearlyInterestRate), YearsToRetunrLoan), 2);

        double friendLoan = Math.Round(priceOfTV * (1 + yearlyInterestFriendLoan), 2);

        if (bankLoan < friendLoan)
        {
            Console.WriteLine("{0:F2} {1}", bankLoan, "Bank");
        }
        else
        {
            Console.WriteLine("{0:F2} {1}", friendLoan, "Friend");
        }
    }
}