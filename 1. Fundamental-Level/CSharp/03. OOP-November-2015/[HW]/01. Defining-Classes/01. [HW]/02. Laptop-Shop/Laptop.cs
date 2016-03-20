using System;

public class Laptop
{
    private string model;
    private string manufacturer;
    private string processor;
    private string RAMMemory;
    private string graphicsCard;
    private string hardDiskDrive;
    private string screen;
    private double price;

    public Laptop(string model, double price)
    {
        this.Model = model;
        this.Price = price;
    }

    public Laptop(string model, double price, string manufacturer)
        : this(model, price)
    {
        this.Manufacturer = manufacturer;
    }

    public Laptop(string model, double price, string manufacturer, string processor)
        : this(model, price, manufacturer)
    {
        this.Processor = processor;
    }

    public Laptop(string model, double price, string manufacturer, string processor, string RAM)
        : this(model, price, manufacturer, processor)
    {
        this.RAM = RAM;
    }

    public Laptop(string model, double price, string manufacturer, string processor, string RAM, string graphicsCard)
        : this(model, price, manufacturer, processor, RAM)
    {
        this.GraphicsCard = graphicsCard;
    }

    public Laptop(string model, double price, string manufacturer, string processor, string RAM, string graphicsCard, string HDD)
        : this(model, price, manufacturer, processor, RAM, graphicsCard)
    {
        this.HDD = HDD;
    }

    public Laptop(string model, double price, string manufacturer, string processor, string RAM, string graphicsCard, string HDD, string screen)
        : this(model, price, manufacturer, processor, RAM, graphicsCard, HDD)
    {
        this.Screen = screen;
    }

    public Laptop(string model, double price, string manufacturer, string processor, string RAM, string graphicsCard, string HDD, string screen, Battery battery)
        : this(model, price, manufacturer, processor, RAM, graphicsCard, HDD, screen)
    {
        this.Battery = battery;
    }

    public string Model
    {
        get { return this.model; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(@"The ""Model"" cannot be empty.");
            }

            this.model = value;
        }
    }
    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(@"The ""Manufacturer"" cannot be empty.");
            }

            this.manufacturer = value;
        }
    }
    public string Processor
    {
        get { return this.processor; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(@"The ""Processor"" cannot be empty.");
            }

            this.processor = value;
        }
    }
    public string RAM
    {
        get { return this.RAMMemory; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(@"The ""RAM"" cannot be empty.");
            }

            this.RAMMemory = value;
        }
    }
    public string GraphicsCard
    {
        get { return this.graphicsCard; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(@"The ""Graphics"" Card cannot be empty.");
            }

            this.graphicsCard = value;
        }
    }
    public string HDD
    {
        get { return this.hardDiskDrive; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(@"The ""HDD"" Card cannot be empty.");
            }

            this.hardDiskDrive = value;
        }
    }
    public string Screen
    {
        get { return this.screen; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(@"The ""Screen"" Card cannot be empty.");
            }

            this.screen = value;
        }
    }
    public double Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The Price cannot be negative.");
            }

            this.price = value;
        }
    }
    public Battery Battery { get; set; }

    public override string ToString()
    {
        if (this.Manufacturer == null)
        {
            return string.Format("Model: {0}\nPrice: {1:f2} lv.", this.Model, this.Price);
        }

        if (!string.IsNullOrEmpty(this.Manufacturer) &&
            string.IsNullOrEmpty(this.Processor))
        {
            return string.Format("Model: {0}\nManufacturer: {1}\nPrice: {2:f2} lv.", this.Model, this.Manufacturer, this.Price);
        }

        if (!string.IsNullOrEmpty(this.Processor) &&
            string.IsNullOrEmpty(this.RAM))
        {
            return string.Format("Model: {0}\nManufacturer: {1}\nProcessor: {2}\nPrice: {3:f2} lv.", this.Model, this.Manufacturer, this.Processor, this.Price);
        }

        if (!string.IsNullOrEmpty(this.RAM) &&
            string.IsNullOrEmpty(this.GraphicsCard))
        {
            return string.Format("Model: {0}\nManufacturer: {1}\nProcessor: {2}\nRAM: {2}\nPrice: {4:f2} lv.", this.Model, this.Manufacturer, this.Processor, this.RAM, this.Price);
        }

        if (!string.IsNullOrEmpty(this.GraphicsCard) &&
           string.IsNullOrEmpty(this.HDD))
        {
            return string.Format("Model: {0}\nManufacturer: {1}\nProcessor: {2}\nRAM: {3}\nGraphics card: {4}\nPrice: {5:f2} lv.", this.Model, this.Manufacturer, this.Processor, this.RAM, this.GraphicsCard, this.Price);
        }

        if (!string.IsNullOrEmpty(this.HDD) &&
           string.IsNullOrEmpty(this.Screen))
        {
            return string.Format("Model: {0}\nManufacturer: {1}\nProcessor: {2}\nRAM: {3}\nGraphics card: {4}\nHDD: {5}\nPrice: {6:f2} lv.", this.Model, this.Manufacturer, this.Processor, this.RAM, this.GraphicsCard, this.HDD, this.Price);
        }

        if (!string.IsNullOrEmpty(this.Screen) &&
           this.Battery == null)
        {
            return string.Format("Model: {0}\nManufacturer: {1}\nProcessor: {2}\nRAM: {3}\nGraphics card: {4}\nHDD: {5}\nScreen: {6}\nPrice: {7} lv.", this.Model, this.Manufacturer, this.Processor, this.RAM, this.GraphicsCard, this.HDD, this.Screen, this.Price);
        }

        if (!string.IsNullOrEmpty(this.Battery.BatteryType) &&
            this.Battery.BatteryLife == 0)
        {
            return string.Format("Model: {0}\nManufacturer: {1}\nProcessor: {2}\nRAM: {3}\nGraphics card: {4}\nHDD: {5}\nScreen: {6}\nBattery: {7}\nPrice: {8:f2} lv.", this.Model, this.Manufacturer, this.Processor, this.RAM, this.GraphicsCard, this.HDD, this.Screen, this.Battery.BatteryType, this.Price);
        }

        return string.Format("Model: {0}\nManufacturer: {1}\nProcessor: {2}\nRAM: {3}\nGraphics card:{4}\nHDD: {5}\nScreen: {6}\nBattery: {7}\nBattery life: {8} hours\nPrice: {9:f2} lv.", this.Model, this.Manufacturer, this.Processor, this.RAM, this.GraphicsCard, this.HDD, this.Screen, this.Battery.BatteryType, this.Battery.BatteryLife, this.Price);
    }
}