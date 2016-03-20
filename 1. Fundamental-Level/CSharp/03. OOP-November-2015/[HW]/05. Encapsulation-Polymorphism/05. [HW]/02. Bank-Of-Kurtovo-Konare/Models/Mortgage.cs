namespace _02.Bank_Of_Kurtovo_Konare.Models
{
    using System;

    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void CalculateInterestRate(int months)
        {
            if (months <= 6 && this.Customer == Customer.Individual)
            {
                Console.WriteLine("Calculated intrest rate for {0} months: 0", months);
                return;
            }

            if (months <= 12 && this.Customer == Customer.Company)
            {
                Console.WriteLine("Calculated intrest rate for {0} months: 0", months);
                return;
            }

            Console.WriteLine("Calculated intrest rate for {0} months: {1:C2}", months, this.Balance * (1 + this.InterestRate * months));
        }
    }
}