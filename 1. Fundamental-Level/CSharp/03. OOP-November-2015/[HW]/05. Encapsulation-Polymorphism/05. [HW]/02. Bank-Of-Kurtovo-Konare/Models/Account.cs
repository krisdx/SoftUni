namespace _02.Bank_Of_Kurtovo_Konare.Models
{
    using System;

    public abstract class Account
    {
        private decimal balance;
        private decimal interestRate;

        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The balance cannot be negative");
                }

                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The interest rate cannot be negative.");
                }

                this.interestRate = value;
            }
        }

        public abstract void CalculateInterestRate(int mounths);

        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public override string ToString()
        {
            return string.Format("Customer type: {0}\nAccount type: {1}\nBalance: {2:c2}", this.Customer, this.GetType().Name, this.Balance);
        }
    }
}