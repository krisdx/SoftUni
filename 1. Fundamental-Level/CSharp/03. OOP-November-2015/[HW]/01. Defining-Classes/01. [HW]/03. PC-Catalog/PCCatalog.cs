using System;
using System.Collections.Generic;
using System.Linq;

public class PCCatalog
{
    public static void Main()
    {
        List<Component> computer1sComponents = new List<Component>
        {
            new Component("Processor", 200),
            new Component("Graphics card", 150),
            new Component("Motherboard", 250),
            new Component("HDD", 300)
        };
        Computer computer1 = new Computer("HP", computer1sComponents);

        List<Component> computer2sComponents = new List<Component>
        {
            new Component("Processor", 10),
            new Component("Graphics card", 1150),
            new Component("Motherboard", 500),
            new Component("HDD", 400, "SSD")
        };
        Computer computer2 = new Computer("Acer", computer2sComponents);

        List<Component> computer3sComponents = new List<Component>
        {
            new Component("Processor", 400, "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache"),
            new Component("Graphics card", 160, "Intel HD Graphics 4400"),
            new Component("Motherboard", 150),
            new Component("HDD", 500, "128GB SSD")
        };
        Computer computer3 = new Computer("Lenovo", computer3sComponents);

        List<Computer> PCCatalog = new List<Computer>()
        {
            computer1,
            computer2, 
            computer3
        };

        var sortedPCCatalog =
            PCCatalog.OrderBy(PC => PC.TotalPrice);
        foreach (var computer in sortedPCCatalog)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(computer);
        }
        Console.WriteLine();
    }
}