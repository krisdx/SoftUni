using System;

public class Component
{
    private string name;
    private decimal price;

    public Component(string componentName, decimal price)
    {
        this.Name = componentName;
        this.Price = price;
    }

    public Component(string componentName, decimal price, string details)
        : this(componentName, price)
    {
        this.Details = details;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The name cannot be empty.");
            }

            this.name = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The price cannot be negative.");
            }

            this.price = value;
        }
    }

    public string Details { get; set; }
}