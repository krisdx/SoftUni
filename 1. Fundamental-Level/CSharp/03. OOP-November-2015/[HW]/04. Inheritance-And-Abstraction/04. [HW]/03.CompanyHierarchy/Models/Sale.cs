namespace CompanyHierarchy.Models
{
    using System;
    using CompanyHierarchy.Interfaces;

    public class Sale : ISale
    {
        private string productName;
        private decimal productPrice;

        public Sale(string productName, DateTime saleDate, decimal price)
        {
            this.ProductName = productName;
            this.SaleDate = saleDate;
            this.ProductPrice = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value.Trim()))
                {
                    throw new ArgumentException("Product name cannot be empty.");
                }

                this.productName = value;
            }
        }

        public DateTime SaleDate { get; set; }

        public decimal ProductPrice
        {
            get { return this.productPrice; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("productPrice", "Product proce cannot be negative.");
                }

                this.productPrice = value;
            }
        }
    }
}