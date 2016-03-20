namespace FarmersCreed.Interfaces
{
    using FarmersCreed.Units;
    using FarmersCreed.Units.Products;

    public interface IProductProduceable
    {
        int ProductionQuantity { get; set; }

        Product GetProduct();
    }
}