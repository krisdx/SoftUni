using System;

public class Student : Person
{
    private string studentNumber;
    private double averageGrade;

    public Student(string firstName, string lastName, int age, string studentNumber, double averageGrade)
        : base(firstName, lastName, age)
    {
        this.StudentNumber = studentNumber;
        this.AverageGrade = averageGrade;
    }

    public string StudentNumber
    {
        get { return this.studentNumber; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The student number cannot be empty.");
            }

            this.studentNumber = value;
        }
    }
    public double AverageGrade
    {
        get { return this.averageGrade; }
        set
        {
            if (value < 2 ||
                value > 6)
            {
                throw new ArgumentOutOfRangeException("The average grade must be in range [2..6]");
            }

            this.averageGrade = value;
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} [Student]\nAge - {2}\nStudent number - {4}\nAverage grade - {5:f2}", this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AverageGrade);
    }
}