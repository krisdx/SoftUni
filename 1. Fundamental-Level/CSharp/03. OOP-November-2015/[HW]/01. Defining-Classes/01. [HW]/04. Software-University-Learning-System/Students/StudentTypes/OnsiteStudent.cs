using System;

public class OnsiteStudent : CurrentStudent
{
    private int numberOfVisits;

    public OnsiteStudent(string firstName, string lastName, int age, string studentNumber, double averageGrade, string currentCourse, int numberOfVisits)
        : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
    {
        this.NumberOfVisits = numberOfVisits;
    }

    public int NumberOfVisits
    {
        get { return this.numberOfVisits; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The number of visits cannot be negative.");
            }

            this.numberOfVisits = value;
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} [Onsite Student]\nAge - {2}\nStudent number - {4}\nAverage grade - {5:f2}\nCurrent course - {6}\nNumber of visits - {7}", this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AverageGrade, this.CurrentCourse, this.NumberOfVisits);
    }
}