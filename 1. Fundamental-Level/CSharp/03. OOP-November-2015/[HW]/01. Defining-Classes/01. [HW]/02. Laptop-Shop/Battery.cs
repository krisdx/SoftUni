using System;

public class Battery
{
    private string battery;
    private float batteryLife;

    public Battery(string type)
    {
        this.BatteryType = type;
    }

    public Battery(string type, float batteryLife)
        :this(type)
    {
        this.BatteryLife = batteryLife;
    }

    public string BatteryType
    {
        get { return this.battery; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("the battey type cannot be empty");
            }

            this.battery = value;
        }
    }
    public float BatteryLife 
    {
        get { return this.batteryLife; }
        set 
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The battery life cannot be zero or negative.");
            }

            this.batteryLife = value;
        }
    }
}