namespace Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using Models;

    public class DataMapper
    {
        private const string DefaultCategoriesFilePath = "../../Data/categories.txt";
        private const string DefaultProductsFilePath = "../../Data/products.txt";
        private const string DefaultOrdersFilePath = "../../Data/orders.txt";

        private string categoriesFilePath;
        private string productsFilePath;
        private string ordersFilePath;

        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.categoriesFilePath = categoriesFileName;
            this.productsFilePath = productsFileName;
            this.ordersFilePath = ordersFileName;
        }

        public DataMapper()
            : this(DefaultCategoriesFilePath, DefaultProductsFilePath, DefaultOrdersFilePath)
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var category = ReadFileLines(this.categoriesFilePath, true);

            return category
                .Select(c => c.Split(','))
                .Select(categoryStr => new Category
                {
                    Id = int.Parse(categoryStr[0]),
                    Name = categoryStr[1],
                    Description = categoryStr[2]
                });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var product = ReadFileLines(this.productsFilePath, true);

            return product
                .Select(pro => pro.Split(','))
                .Select(productStr => new Product
                {
                    Id = int.Parse(productStr[0]),
                    Name = productStr[1],
                    CategoryId = int.Parse(productStr[2]),
                    UnitPrice = decimal.Parse(productStr[3]),
                    UnitsInStock = int.Parse(productStr[4]),
                });
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var order = ReadFileLines(this.ordersFilePath, true);

            return order
                .Select(ord => ord.Split(','))
                .Select(orderStr => new Order
                {
                    Id = int.Parse(orderStr[0]),
                    ProductId = int.Parse(orderStr[1]),
                    Quantity = int.Parse(orderStr[2]),
                    Discount = decimal.Parse(orderStr[3]),
                });
        }

        private List<string> ReadFileLines(string filePath, bool hasHeader)
        {
            var allLines = new List<string>();

            using (var reader = new StreamReader(filePath))
            {
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    allLines.Add(currentLine);

                    currentLine = reader.ReadLine();
                }
            }

            return allLines;
        }
    }
}