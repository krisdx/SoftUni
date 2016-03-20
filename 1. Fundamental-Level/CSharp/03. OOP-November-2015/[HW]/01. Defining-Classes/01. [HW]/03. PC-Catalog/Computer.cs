using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Globalization;
using System.Text;

public class Computer
{
    private string name;
    private List<Component> componentsList;

    public Computer(string name, List<Component> componentsList)
    {
        this.Name = name;
        this.ComponentsList = componentsList;
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

    public List<Component> ComponentsList
    {
        get { return this.componentsList; }
        set
        {
            if (value.Count == 0)
            {
                throw new ArgumentNullException("The computer cannot be without components!");
            }

            this.componentsList = value;
        }
    }

    public decimal TotalPrice
    {
        get
        {
            return CalculatePrice(this);
        }
    }

    private decimal CalculatePrice(Computer computer)
    {
        decimal price = 0;
        foreach (var component in computer.componentsList)
        {
            price += component.Price;
        }

        return price;
    }

    public override string ToString()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg");
        StringBuilder output = new StringBuilder();
        output.AppendLine(string.Format("Computer name: {0}", this.Name));
        foreach (var component in componentsList)
        {
            output.AppendLine(string.Format("-{0} - {1:C2}", component.Name, component.Price));
            if (component.Details != null &&
                component.Details != string.Empty)
            {
                output.AppendLine(string.Format(" -Details: {0}", component.Details));
            }
        }

        output.AppendLine();
        output.AppendFormat("Total Prce: {0:c2}", this.TotalPrice);

        return output.ToString();
    }
}