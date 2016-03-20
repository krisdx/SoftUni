namespace _02.Bank_Of_Kurtovo_Konare.Models
{
    using System;

    public class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void CalculateInterestRate(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                Console.WriteLine("Calculated intrest rate for {0} months: 0", months);
                return;
            }

            Console.WriteLine("Calculated intrest rate for {0} months: {1:c2}", months,this.Balance * (1 + this.InterestRate * months)); 
        }

        public void DrawMoney(decimal amount)
        {
            if (this.Balance - amount < 0)
            {
                System.Console.WriteLine("Not enough money!");
                return;
            }

            this.Balance -= amount;
        }
    }
}