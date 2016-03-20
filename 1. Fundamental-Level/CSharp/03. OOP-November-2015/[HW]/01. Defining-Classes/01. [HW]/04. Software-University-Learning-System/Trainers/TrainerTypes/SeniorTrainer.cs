using System;

public class SeniorTrainer : Trainer
{
    public SeniorTrainer(string firstName, string lastName, int age)
        :base(firstName, lastName, age)
    {
    }

    public void DeleteCourse(string courseName)
    {
        Console.WriteLine(@"The course ""{0}"" has been removed!", courseName);
    }

    public override string ToString()
    {
        return string.Format("{0} {1} [Senior Trainer]\nAge - {2}", this.FirstName, this.LastName, this.Age);
    }
}