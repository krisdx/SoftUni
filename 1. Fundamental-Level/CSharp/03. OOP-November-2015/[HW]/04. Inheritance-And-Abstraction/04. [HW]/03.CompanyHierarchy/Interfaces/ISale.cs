namespace CompanyHierarchy.Interfaces
{
    using System;

    public interface ISale
    {
        string ProductName { get; set; }

        DateTime SaleDate { get; set; }

        decimal ProductPrice { get; set; }
    }
}