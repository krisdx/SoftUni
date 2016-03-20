namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using FurnitureManufacturer.Models.Chairs;

    public class Chair : BaseChair
    {
        public Chair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }
    }
}