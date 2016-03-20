namespace FarmersCreed.Interfaces
{
    using FarmersCreed.Units;
    using FarmersCreed.Units.Products;

    public interface IEdible : IProduct 
    {
        FoodType FoodType { get; set; }

        int HealthEffect { get; set; }
    }
}