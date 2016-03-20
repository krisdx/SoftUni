using System;
using System.Net.Mail;

public class Person
{
    private string name;
    private int age;
    private string email;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The name cannot be empty");
            }

            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value <= 0 ||
                value > 100)
            {
                throw new ArgumentOutOfRangeException("The age must be in the range [1..100]");
            }

            this.age = value;
        }
    }

    public string Email
    {
        get { return this.email; }
        set
        {
            if (IsEmailAdressValid(value))
            {
                this.email = value;
            }
        }
    }

    private bool IsEmailAdressValid(string emails)
    {
        try
        {
            MailAddress emailAdress = new MailAddress(email);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Person(string name, int age, string email)
        : this(name, age)
    {
        this.Email = email;
    }

    public override string ToString()
    {
        return string.Format("{0}\nAge: {1}\nEmail: {2}", this.Name, this.Age, this.Email ?? "[ No email ]");
    }
}