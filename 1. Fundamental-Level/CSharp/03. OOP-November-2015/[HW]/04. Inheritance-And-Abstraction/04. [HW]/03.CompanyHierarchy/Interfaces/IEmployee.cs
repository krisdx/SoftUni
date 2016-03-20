namespace CompanyHierarchy.Interfaces
{
using CompanyHierarchy.Models;

   public interface IEmployee
    {
        Department Department { get; set; }

        decimal Salary { get; set; }
    }
}