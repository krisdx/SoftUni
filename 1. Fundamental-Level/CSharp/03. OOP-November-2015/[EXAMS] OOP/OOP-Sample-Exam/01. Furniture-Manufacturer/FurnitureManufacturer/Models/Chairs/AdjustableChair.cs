namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using FurnitureManufacturer.Models.Chairs;

    public class AdjustableChair : BaseChair, IAdjustableChair
    {
        public AdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            :base(model, materialType, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
    }
}