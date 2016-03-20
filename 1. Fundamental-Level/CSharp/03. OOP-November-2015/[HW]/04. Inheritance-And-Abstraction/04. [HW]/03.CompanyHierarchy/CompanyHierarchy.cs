using CompanyHierarchy.Models;

namespace _03.CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    public class CompanyHierarchy
    {
        public static void Main()
        {
            Manager manager1 = new Manager("0000000001", "Manager1", "Manager1 Last name", Department.Accounting, 123m);
            Manager manager2 = new Manager("0000000002", "Manager2", "Manager2 Last name", Department.Sales, 3124m);
            Manager manager3 = new Manager("0000000003", "Manager2", "Manager2 Last name", Department.Marketing, 1423m);

            SalesEmployee salesEmployee1 = new SalesEmployee("0000000004", "SalesEmployee1", "SalesEmployee1 Last name", Department.Accounting, 512m);
            SalesEmployee salesEmployee2 = new SalesEmployee("0000000005", "SalesEmployee2", "SalesEmployee2 Last name", Department.Marketing, 513m);
            SalesEmployee salesEmployee3 = new SalesEmployee("0000000006", "SalesEmployee3", "SalesEmployee3 Last name", Department.Production, 1000m);

            Developer developer1 = new Developer("0000000007", "Developer1", "Developer1 Last name", Department.Marketing, 5523m);
            Developer developer2 = new Developer("0000000008", "Developer2", "Developer2 Last name", Department.Sales, 513m);
            Developer developer3 = new Developer("0000000009", "Developer3", "Developer3 Last name", Department.Accounting, 523m);

            Sale sale = new Sale("graphic card", DateTime.Now, 220m);
            Project project = new Project("OOP", "OOP course", DateTime.Now);

            manager1.AddEmployees(new HashSet<Employee> { salesEmployee1, developer3 });
            salesEmployee1.AddSales(new HashSet<Sale> { sale });
            developer1.AddProjects(new HashSet<Project> { project });

            IList<Employee> employees = new List<Employee>
            {
                manager1,
                manager2,
                manager3,
                salesEmployee1,
                salesEmployee2,
                salesEmployee3,
                developer1,
                developer2,
                developer3
            };

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}