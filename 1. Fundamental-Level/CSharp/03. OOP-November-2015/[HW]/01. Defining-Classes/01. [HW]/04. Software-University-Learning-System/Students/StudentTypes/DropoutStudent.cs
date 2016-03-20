using System;

public class DropoutStudent : Student
{
    private string dropoutReason;

    public DropoutStudent(string firstName, string lastName, int age, string studentNumber, double averageGrade, string dropoutReason)
        : base(firstName, lastName, age, studentNumber, averageGrade)
    {
        this.DropoutReason = dropoutReason;
    }

    public string DropoutReason 
    {
        get { return this.dropoutReason; }
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The dropout reason cannot be empty."); 
            }

            this.dropoutReason = value;
        }
    }   

    public void Reapply()
    {
        Console.WriteLine("{0} {1} - {2} yeadrs old.\nStudent number - {3}\nAverage grade: {4:f2}", this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AverageGrade);
        Console.WriteLine("Dropout reason: {0}", this.DropoutReason);
    }

    public override string ToString()
    {
        return string.Format("{0} {1} [Dropout Student]\nAge - {2}\nStudent number - {4}\nAverage grade - {5:f2}\nCurrent course - {6}", this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AverageGrade);
    }
}