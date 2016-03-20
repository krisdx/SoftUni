using System;

public class Player
{
    private const  int MinimalAllowedYear = 1980;

    private string firstName;
    private string lastName;
    private decimal salary;
    private DateTime dateOfBirth;

    public Player(string firstName, string lastName, decimal salary, DateTime dateOfBirth, Team team)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Salary = salary;
        this.DateOfBirth = dateOfBirth;
        this.Team = team;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The first name's length cannot be smaller than 3.");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The last name's length cannot be smaller than 3.");
            }

            this.lastName = value;
        }
    }

    public decimal Salary
    {
        get
        {
            return this.salary;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The salary cannot be negative.");
            }

            this.salary = value;
        }
    }

    public DateTime DateOfBirth
    {
        get
        {
            return this.dateOfBirth;
        }
        set
        {
            if (value.Year < MinimalAllowedYear)
            {
                throw new ArgumentOutOfRangeException(string.Format("Date of Birth’s year cannot be lower than {0}.", MinimalAllowedYear));
            }

            this.dateOfBirth = value;
        }
    }

    public Team Team { get; set; }
}