namespace FarmersCreed.Interfaces
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Units;
    using FarmersCreed.Units.Plants;
    using FarmersCreed.Units.Animals;
    using FarmersCreed.Units.Products;

    public interface IFarm 
    {
        List<Plant> Plants { get; }

        List<Animal> Animals { get; }

        List<Product> Products { get; }

        void AddProduct(Product product);

        void Exploit(IProductProduceable productProducer);

        void Feed(Animal animal, IEdible edibleProduct, int productQuantity);

        void Water(Plant plant);

        void UpdateFarmState();
    }
}