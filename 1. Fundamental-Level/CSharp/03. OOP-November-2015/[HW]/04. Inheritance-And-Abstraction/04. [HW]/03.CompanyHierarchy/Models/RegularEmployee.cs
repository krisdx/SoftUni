namespace CompanyHierarchy.Models
{
    using CompanyHierarchy.Interfaces;

    public class RegularEmployee : Employee
    {
        public RegularEmployee(string id, string firstName, string lastName, Department department, decimal salary)
            : base(id, firstName, lastName, department, salary)
        {
        }
    }
}