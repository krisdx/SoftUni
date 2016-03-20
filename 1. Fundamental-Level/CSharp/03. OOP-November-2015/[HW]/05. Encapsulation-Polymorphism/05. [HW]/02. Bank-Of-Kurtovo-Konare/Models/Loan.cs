namespace _02.Bank_Of_Kurtovo_Konare.Models
{
    using System;

    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void CalculateInterestRate(int months)
        {
            if (months <= 3 && this.Customer == Customer.Individual)
            {
                Console.WriteLine("Calculated intrest rate for {0} months: 0", months);
                return;
            }

            if (months <= 2 && this.Customer == Customer.Company)
            {
                Console.WriteLine("Calculated intrest rate for {0} months: 0", months);
                return;
            }

            Console.WriteLine("Calculated intrest rate for {0} months: {1:c2}", months, this.Balance * (1 + this.InterestRate * months)); 
        }
    }
}