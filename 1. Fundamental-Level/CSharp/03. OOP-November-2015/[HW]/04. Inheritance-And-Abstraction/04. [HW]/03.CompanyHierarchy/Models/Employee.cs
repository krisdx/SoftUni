namespace CompanyHierarchy.Models
{
    using System;
    using CompanyHierarchy.Interfaces;

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;

        protected Employee(string id, string firstName, string lastName, Department department, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Department = department;
            this.Salary = salary;
        }

        public Department Department { get; set; }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("salary", "The salary cannot be negative!");
                }

                this.salary = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Department: {0}\nSalary: {1}\n", this.Department, this.Salary);
        }
    }
}