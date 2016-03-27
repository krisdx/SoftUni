namespace CollectionOfProducts
{
    using System.Collections.Generic;

    public interface ICollectionOfProducts
    {
        void Add(string id, string title, string supplier, double price);

        bool Remove(string id);

        IEnumerable<Product> FindProductsInPriceRange(double startPriceRange, double endPriceRange);

        IEnumerable<Product> FindProductsByTitle(string title);

        IEnumerable<Product> FindProductsByTitleAndPrice(string title, double price);

        IEnumerable<Product> FindProductsByTitleAndPriceRange(string title, double startPriceRange, double endPriceRange);

        IEnumerable<Product> FindProductsBySupplierAndPrice(string supplier, double price);

        IEnumerable<Product> FindProductsBySupplierAndPriceRange(string supplier, double startPriceRange, double endPriceRange);
    }
}