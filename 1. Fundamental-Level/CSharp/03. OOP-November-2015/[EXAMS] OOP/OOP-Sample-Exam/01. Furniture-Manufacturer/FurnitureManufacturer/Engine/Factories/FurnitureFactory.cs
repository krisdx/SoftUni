namespace FurnitureManufacturer.Engine.Factories
{
    using System;

    using Interfaces;
    using Interfaces.Engine;
    using Models;
    using FurnitureManufacturer.Models.Tables;

    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            string type = this.GetMaterialType(materialType);
            return new Table(model, type, price, height, length, width);
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            string type = this.GetMaterialType(materialType); return new Chair(model, type, price, height, numberOfLegs);
        }

        public IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            string type = this.GetMaterialType(materialType); return new AdjustableChair(model, type, price, height, numberOfLegs);
        }

        public IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            string type = this.GetMaterialType(materialType); return new ConvertibleChair(model, type, price, height, numberOfLegs);
        }

        private string GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden.ToString();
                case Leather:
                    return MaterialType.Leather.ToString();
                case Plastic:
                    return MaterialType.Plastic.ToString();
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }
    }
}