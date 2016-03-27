namespace StudentsAndCourses
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            int compareIndex = this.LastName.CompareTo(other.LastName);
            if (compareIndex == 0)
            {
                compareIndex = this.FirstName.CompareTo(other.FirstName);
            }

            return compareIndex;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        } 
    }
}