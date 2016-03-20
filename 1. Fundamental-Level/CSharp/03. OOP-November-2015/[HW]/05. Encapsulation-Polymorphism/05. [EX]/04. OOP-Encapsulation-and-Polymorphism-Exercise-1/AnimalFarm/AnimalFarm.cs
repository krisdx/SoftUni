namespace AnimalFarm
{
    using System;

    public class AnimalFarm
    {
        public static void Main()
        {
            Chicken chicken = new Chicken("Mara", 100);
            Console.WriteLine(chicken.ProductPerDay);
        }
    }
}
