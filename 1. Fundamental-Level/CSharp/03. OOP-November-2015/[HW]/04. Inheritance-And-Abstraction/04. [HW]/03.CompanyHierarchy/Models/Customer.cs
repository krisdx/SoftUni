namespace CompanyHierarchy.Models
{
    using System;
    using CompanyHierarchy.Interfaces;

    public class Customer : Person, ICustomer
    {
        private decimal purchasesAmmount;

        public Customer(string id, string firstName, string lastName, decimal purchasesAmmount)
            : base(id, firstName, lastName)
        {
            this.PurchasesAmmount = purchasesAmmount;
        }

        public void AddPurchasePrice(decimal purchasePrice)
        {
            this.PurchasesAmmount += purchasePrice;
        }

        public decimal PurchasesAmmount
        {
            get { return this.purchasesAmmount; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("purchasesAmmount", "Purchases ammount cannot be empty!");
                }

                this.purchasesAmmount = value;
            }
        }

        public string ToString()
        {
            return base.ToString() + string.Format("Purchases ammount: {0}\n", this.PurchasesAmmount);
        }
    }
}