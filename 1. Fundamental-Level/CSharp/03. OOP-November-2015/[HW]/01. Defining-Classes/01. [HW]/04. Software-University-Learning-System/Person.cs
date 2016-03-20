using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public string FirstName 
    {
        get { return this.firstName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The first name cannot be empty.");
            }

            this.firstName = value;
        }
    }
    public string LastName 
    {
        get { return this.lastName; }
        set 
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The last name cannot be empty.");
            }

            this.lastName = value;
        }
    }
    public int Age 
    {
        get { return this.age; }
        set
        {
            if (age < 0 ||
                age > 100)
            {
                throw new ArgumentOutOfRangeException("The age must be in range [0..100].");
            }

            this.age = value;
        }
    }

    public override string ToString()
    {
        return string.Format("First Name - {0}, Last Name - {1}, Age - {2}", this.FirstName, this.LastName, this.Age);
    }
}