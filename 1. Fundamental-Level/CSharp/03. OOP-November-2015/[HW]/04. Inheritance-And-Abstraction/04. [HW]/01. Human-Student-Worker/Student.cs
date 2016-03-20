using System;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }
        set
        {
            if (value.Length < 4 ||
                value.Length > 10)
            {
                throw new ArgumentOutOfRangeException("The length of the faculty number must be in range [5..10].");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} - {2}", this.FirstName, this.LastName, this.facultyNumber);
    }
}