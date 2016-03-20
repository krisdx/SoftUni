namespace FarmersCreed.Units
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using FarmersCreed.Interfaces;
    using FarmersCreed.Units.Plants;
    using FarmersCreed.Units.Animals;
    using FarmersCreed.Units.Products;
    using System.Text;

    public class Farm : GameObject, IFarm
    {
        public Farm(string id)
            : base(id)
        {
            this.Animals = new List<Animal>();
            this.Plants = new List<Plant>();
            this.Products = new List<Product>();
        }

        public List<Plant> Plants { get; private set; }

        public List<Animal> Animals { get; private set; }

        public List<Product> Products { get; private set; }

        public void AddProduct(Product product)
        {
            this.Products.Add(product);
        }

        public void Exploit(IProductProduceable productProducer)
        {
            this.Products.Add(productProducer.GetProduct());
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            animal.Eat(edibleProduct, productQuantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            bool hasAliveAnimals =
                this.Animals.Any(animal => animal.IsAlive);
            if (hasAliveAnimals)
            {
                foreach (var animal in this.Animals.Where(a => a.IsAlive))
                {
                    animal.Starve();
                }
            }

            foreach (var plant in this.Plants)
            {
                if (!plant.HasGrown)
                {
                    plant.Grow();
                }
                else
                {
                    plant.Wither();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(string.Format("--{0} {1}", this.GetType().Name, this.Id));

            var sortedAliveAnimals = this.Animals
                .Where(animal => animal.IsAlive)
                .OrderBy(animal => animal.Id);
            foreach (var animal in sortedAliveAnimals)
            {
                output.AppendLine(animal.ToString());
            }

            var sortedAlivePlants = this.Plants
                .Where(plant => plant.IsAlive)
                .OrderBy(plant => plant.Health)
                .ThenBy(plant => plant.Id);
            foreach (var plant in sortedAlivePlants)
            {
                output.AppendLine(plant.ToString());
            }

            var sortedProducts = this.Products
                .OrderBy(product => product.ProductType)
                .ThenBy(product => product.Quantity)
                .ThenByDescending(product => product.Id);
            foreach (var product in sortedProducts)
            {
                output.AppendLine(product.ToString());
            }

            return output.ToString();
        }
    }
}