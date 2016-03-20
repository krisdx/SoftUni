using System;

public class CurrentStudent : Student
{
    private string currentCourse;

    public CurrentStudent(string firstName, string lastName, int age, string studentNumber, double averageGrade, string currentCourse)
        :base(firstName, lastName, age, studentNumber, averageGrade)
    {
        this.CurrentCourse = currentCourse;
    }

    public string CurrentCourse 
    {
        get { return this.currentCourse; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The current course cannot be empty.");
            }

            this.currentCourse = value;
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} [Current Student]\nAge - {2}\nStudent number - {3}\nAverage grade - {4:f2}\nCurrent course - {5}", this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AverageGrade, this.CurrentCourse);
    }
}