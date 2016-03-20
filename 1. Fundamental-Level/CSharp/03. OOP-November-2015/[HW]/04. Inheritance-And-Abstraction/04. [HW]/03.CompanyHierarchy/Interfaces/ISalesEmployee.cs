namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;
    using CompanyHierarchy.Models;

    public interface ISalesEmployee
    {
        ISet<Sale> Sales { get; set; }

        void AddSales(ISet<Sale> sales);
    }
}