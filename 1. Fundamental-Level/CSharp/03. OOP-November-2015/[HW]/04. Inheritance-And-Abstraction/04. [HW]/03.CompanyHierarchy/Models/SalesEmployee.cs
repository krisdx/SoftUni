namespace CompanyHierarchy.Models
{
    using System.Collections.Generic;
    using CompanyHierarchy.Interfaces;

    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        public SalesEmployee(string id, string firstName, string lastName, Department department, decimal salary, ISet<Sale> sales = null)
            : base(id, firstName, lastName, department, salary)
        {
            this.Sales = sales ?? new HashSet<Sale>();
        }

        public ISet<Sale> Sales { get; set; }

        public void AddSales(ISet<Sale> sales)
        {
            foreach (var sale in sales)
            {
                this.Sales.Add(sale);
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Number of sales: {0}\n", this.Sales.Count);
        }
    }
}