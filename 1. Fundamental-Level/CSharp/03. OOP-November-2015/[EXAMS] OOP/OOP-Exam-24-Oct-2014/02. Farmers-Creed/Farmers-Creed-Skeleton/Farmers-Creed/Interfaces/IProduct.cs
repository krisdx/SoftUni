namespace FarmersCreed
{
    using FarmersCreed.Units;
    using FarmersCreed.Units.Products;

    public interface IProduct
    {
        ProductType ProductType { get; set; }

        int Quantity { get; set; }
    }
}