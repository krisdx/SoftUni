using System;

public class Trainer : Person
{
    public Trainer(string firstName, string lastName, int age)
        :base(firstName, lastName, age)
    {
    }

    public void CreateCourse(string courseName)
    {
        Console.WriteLine(@"The course ""{0}"" has been created!", courseName);
    }

    public override string ToString()
    {
        return string.Format("{0} {1} [Trainer]\nAge - {2}", this.FirstName, this.LastName, this.Age);
    }
}