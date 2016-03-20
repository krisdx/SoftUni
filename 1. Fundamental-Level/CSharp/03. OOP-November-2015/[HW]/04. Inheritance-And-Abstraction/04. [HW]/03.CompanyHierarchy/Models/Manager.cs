namespace CompanyHierarchy.Models
{
    using System.Collections.Generic;
    using CompanyHierarchy.Interfaces;

    public class Manager : Employee, IManager
    {
        public Manager(string id, string firstName, string lastName, Department department, decimal salary, ISet<Employee> employees = null)
            : base(id, firstName, lastName, department, salary)
        {
            this.Employees = employees ?? new HashSet<Employee>();
        }

        public ISet<Employee> Employees { get; set; }

        public void AddEmployees(ISet<Employee> employees)
        {
            foreach (var employee in employees)
            {
                this.Employees.Add(employee);
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Employees to manage: {0}\n", this.Employees.Count);
        }
    }
}