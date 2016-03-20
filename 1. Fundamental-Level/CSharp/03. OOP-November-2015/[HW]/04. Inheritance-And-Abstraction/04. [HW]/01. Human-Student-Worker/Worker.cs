using System;

public class Worker : Human
{
    private double weekSalary;
    private int workHourPerDay;

    public Worker(string firstName, string lastName, double weekSalary, int workHourPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHourPerDay;
    }

    public double WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The work hours per day cannot be nagative.");
            }

            this.weekSalary = value;
        }
    }
    public int WorkHoursPerDay
    {
        get
        {
            return this.workHourPerDay;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The work hours per day cannot be nagative.");
            }

            this.workHourPerDay = value;
        }
    }

    public double MoneyPerHour()
    {
        return this.WeekSalary / this.WorkHoursPerDay;
    }

    public override string ToString()
    {
        return string.Format("{0} {1}\nWeek Salary - {2}\nWork hours per day - {3}\n", this.FirstName, this.LastName, this.WeekSalary, this.WorkHoursPerDay);
    }
}