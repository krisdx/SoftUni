namespace CollectionOfProducts
{
    using System.Collections.Generic;
    using System.Text;

    using Wintellect.PowerCollections;

    /// <summary>
    /// Collection of unique products that provides fast search and delete operations.  
    /// </summary>
    public class CollectionOfProducts : ICollectionOfProducts
    {
        private Dictionary<string, Product> byId;
        private MultiDictionary<string, Product> byTitle;
        private MultiDictionary<string, Product> byTitleAndPrice;
        private MultiDictionary<string, Product> bySupplierAndPrice;
        private Dictionary<string, OrderedMultiDictionary<double, Product>> byTitleAndPriceRange;
        private Dictionary<string, OrderedMultiDictionary<double, Product>> bySupplierAndPriceRange;
        private OrderedMultiDictionary<double, Product> byPriceRange;

        public CollectionOfProducts()
        {
            this.byId = new Dictionary<string, Product>();
            this.byTitle = new MultiDictionary<string, Product>(false);
            this.byTitleAndPrice = new MultiDictionary<string, Product>(false);
            this.byTitleAndPriceRange = new Dictionary<string, OrderedMultiDictionary<double, Product>>();
            this.bySupplierAndPrice = new MultiDictionary<string, Product>(false);
            this.bySupplierAndPriceRange = new Dictionary<string, OrderedMultiDictionary<double, Product>>();
            this.byPriceRange = new OrderedMultiDictionary<double, Product>(false);
        }

        public int Count
        {
            get { return this.byId.Count; }
        }

        /// <summary>
        /// Adds a new product to the collection.
        /// </summary>
        /// <param name="id">The unique id</param>
        /// <param name="title">The title</param>
        /// <param name="supplier">The supplier</param>
        /// <param name="price">The price</param>
        public void Add(string id, string title, string supplier, double price)
        {
            var product = new Product(id, title, supplier, price);

            // Add by Id
            this.byId[id] = product;

            // Add by title
            if (!this.byTitle.ContainsKey(title))
            {
                this.byTitle.Add(product.Title, product);
            }
            else
            {
                this.byTitle[product.Title].Add(product);
            }

            // Add by title and price
            string titleAndPriceKey = this.GetTitleAndPriceKey(title, price);
            if (!this.byTitleAndPrice.ContainsKey(titleAndPriceKey))
            {
                this.byTitleAndPrice.Add(titleAndPriceKey, product);
            }
            else
            {
                this.byTitleAndPrice[titleAndPriceKey].Add(product);
            }

            // Add by supplier and price 
            string supplierAndPriceKey = this.GetSupplierAndPriceKey(supplier, price);
            if (!this.bySupplierAndPrice.ContainsKey(supplierAndPriceKey))
            {
                this.bySupplierAndPrice.Add(supplierAndPriceKey, product);
            }
            else
            {
                this.bySupplierAndPrice[supplierAndPriceKey].Add(product);
            }

            // Add by title and price range 
            if (!this.byTitleAndPriceRange.ContainsKey(title))
            {
                this.byTitleAndPriceRange.Add(title, new OrderedMultiDictionary<double, Product>(false));
            }
            this.byTitleAndPriceRange[title][price].Add(product);

            // Add by supplier and price range
            if (!this.bySupplierAndPriceRange.ContainsKey(supplier))
            {
                this.bySupplierAndPriceRange.Add(supplier, new OrderedMultiDictionary<double, Product>(false));
            }
            this.bySupplierAndPriceRange[supplier][price].Add(product);

            // Add by price range
            if (!this.byPriceRange.ContainsKey(price))
            {
                this.byPriceRange.Add(price, product);
            }
            else
            {
                this.byPriceRange[price].Add(product);
            }
        }

        public bool Remove(string id)
        {
            Product product = this.GetProduct(id);
            if (product == null)
            {
                return false;
            }

            // Remove by id
            this.byId.Remove(id);

            // Remove by title
            this.byTitle[product.Title].Remove(product);

            // Remove by title and price
            string titleAndPriceKey = this.GetTitleAndPriceKey(product.Title, product.Price);
            this.byTitleAndPrice[titleAndPriceKey].Remove(product);

            // Remove by title and price range
            this.byTitleAndPriceRange.Remove(product.Title);

            // Remove by supplier and price
            string supplierAndPriceKey = this.GetSupplierAndPriceKey(product.Supplier, product.Price);
            this.bySupplierAndPrice.Remove(supplierAndPriceKey);

            // Remove by supplier and price range
            this.bySupplierAndPriceRange.Remove(product.Supplier);

            // Remove by price range
            this.byPriceRange.Remove(product.Price);

            return true;
        }

        public IEnumerable<Product> FindProductsByTitle(string title)
        {
            if (!this.byTitle.ContainsKey(title))
            {
                return null;
            }

            return this.byTitle[title];
        }

        public IEnumerable<Product> FindProductsByTitleAndPrice(string title, double price)
        {
            string titleAndPricekey = this.GetTitleAndPriceKey(title, price);
            if (!this.byTitleAndPrice.ContainsKey(titleAndPricekey))
            {
                return null;
            }

            return this.byTitleAndPrice[titleAndPricekey];
        }

        public IEnumerable<Product> FindProductsInPriceRange(double startPriceRange, double endPriceRange)
        {
            var productsInRange = this.byPriceRange.Range(startPriceRange, true, endPriceRange, true);
            foreach (var keyValuePair in productsInRange)
            {
                foreach (var product in keyValuePair.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindProductsByTitleAndPriceRange(string title, double startPriceRange, double endPriceRange)
        {
            var productsInRange = this.byTitleAndPriceRange[title].Range(startPriceRange, true, endPriceRange, true);
            foreach (var valuePair in productsInRange)
            {
                foreach (var product in valuePair.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindProductsBySupplierAndPrice(string supplier, double price)
        {
            string supplierAndPriceKey = this.GetSupplierAndPriceKey(supplier, price);
            return this.bySupplierAndPrice[supplierAndPriceKey];
        }

        public IEnumerable<Product> FindProductsBySupplierAndPriceRange(string supplier, double startPriceRange, double endPriceRange)
        {
            var productsInRange = this.bySupplierAndPriceRange[supplier].Range(startPriceRange, true, endPriceRange, true);
            foreach (var keyValuePair in productsInRange)
            {
                foreach (var product in keyValuePair.Value)
                {
                    yield return product;
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(new string('-', 20));
            foreach (var pair in this.byId)
            {
                output.AppendLine(pair.Value.ToString());
                output.AppendLine(new string('-', 20));
            }

            return output.ToString().Trim();
        }

        private Product GetProduct(string id)
        {
            Product product;
            this.byId.TryGetValue(id, out product);

            return product;
        }

        private string GetTitleAndPriceKey(string title, double price)
        {
            string titleAndPriceKey = title + "|" + price;
            return titleAndPriceKey;
        }

        private string GetSupplierAndPriceKey(string supplier, double price)
        {
            string supplierAndPriceKey = supplier + "|" + price;
            return supplierAndPriceKey;
        }
    }
}