namespace CompanyHierarchy.Models
{
    using System;
    using System.Text.RegularExpressions;
    using CompanyHierarchy.Interfaces;

    public abstract class Person : IPerson
    {
        private string id;
        private string firstName;
        private string lastName;

        protected Person(string id, string firstName, string lastName)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string ID
        {
            get { return this.id; }
            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z\d]{10}$"))
                {
                    throw new ArgumentOutOfRangeException("id", "ID should be 10 symbols long and contain only letters and digits!");
                }

                this.id = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("firstName", "First name cannot be empty!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("lastName", "Last name cannot be empty!");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\nFrist name: {1}\nLast name: {2}\nRole: {3}\n",
                this.ID, this.FirstName, this.LastName, this.GetType().Name);
        }
    }
}