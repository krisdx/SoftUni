namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;
    using CompanyHierarchy.Models;

    public interface IManager
    {
        ISet<Employee> Employees { get; set; }

        void AddEmployees(ISet<Employee> employees);
    }
}