namespace Online_Market
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    using Wintellect.PowerCollections;

    public class OnlineMarketMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var superMarket = new SuperMarket();
            var output = new StringBuilder();

            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] commandParams = line.Split();
                if (commandParams[0] == "add")
                {
                    string name = commandParams[1];
                    string type = commandParams[3];
                    double price = double.Parse(commandParams[2]);
                    string result = superMarket.Add(name, type, price);
                    output.AppendLine(result);
                }
                else
                {
                    if (commandParams[2] == "type")
                    {
                        var result = superMarket.FilterByType(commandParams[3]);
                        if (result == null)
                        {
                            output.AppendFormat("Error: Type {0} does not exists\n", commandParams[3]);
                        }
                        else
                        {
                            output.AppendFormat("Ok: {0}\n", string.Join(", ", result));
                        }
                    }
                    else
                    {
                        double minRange = 0;
                        double maxRange = double.MaxValue;
                        if (commandParams[3] == "from")
                        {
                            minRange = double.Parse(commandParams[4]);
                            if (commandParams.Length > 5)
                            {
                                maxRange = double.Parse(commandParams[6]);
                            }
                        }
                        else
                        {
                            maxRange = double.Parse(commandParams[4]);
                        }

                        var result = superMarket.FilterByPriceRange(minRange, maxRange);
                        output.AppendFormat("Ok: {0}\n", string.Join(", ", result));

                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }

    public class SuperMarket
    {
        private HashSet<Product> products;
        private HashSet<double> prices;
        private Dictionary<string, SortedSet<Product>> byType;
        private OrderedMultiDictionary<double, Product> byPrice;

        public SuperMarket()
        {
            this.products = new HashSet<Product>();
            this.prices = new HashSet<double>();
            this.byType = new Dictionary<string, SortedSet<Product>>();
            this.byPrice = new OrderedMultiDictionary<double, Product>(false);
        }

        public string Add(string name, string type, double price)
        {
            var product = new Product(name, type, price);
            if (this.products.Contains(product))
            {
                return string.Format("Error: Product {0} already exists", name);
            }

            this.products.Add(product);

            if (!this.byType.ContainsKey(type))
            {
                this.byType[type] = new SortedSet<Product>();
            }
            this.byType[type].Add(product);

            this.byPrice[price].Add(product);
            this.prices.Add(price);

            return string.Format("Ok: Product {0} added successfully", name);
        }

        public IEnumerable<Product> FilterByType(string type)
        {
            if (!this.byType.ContainsKey(type))
            {
                return null;
            }

            var productsByType = this.byType[type];

            var list = new List<Product>();
            int count = 0;
            foreach (var product in productsByType)
            {
                count++;
                if (count == 11)
                {
                    break;
                }

                list.Add(product);
            }

            return list;
        }

        public IEnumerable<Product> FilterByPriceRange(double minPrice, double maxPrice)
        {
            var pricesInRange = this.byPrice.Range(minPrice, true, maxPrice, true);
            int counter = 0;
            foreach (var pair in pricesInRange)
            {
                foreach (var product in pair.Value)
                {
                    counter++;
                    if (counter == 11)
                    {
                        yield break;
                    }

                    yield return product;
                }
            }
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, string type, double price)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() +
                   this.Price.GetHashCode() +
                   this.Type.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Product;
            if (other == null)
            {
                return false;
            }

            return this.Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }

        public int CompareTo(Product other)
        {
            int compareIndex = this.Price.CompareTo(other.Price);
            if (compareIndex == 0)
            {
                compareIndex = this.Name.CompareTo(other.Name);
                if (compareIndex == 0)
                {
                    compareIndex = this.Type.CompareTo(other.Type);
                }
            }

            return compareIndex;
        }
    }
}