namespace ProductsInRange
{
    using System;
    using System.Globalization;
    using System.Threading;

    using Wintellect.PowerCollections;

    public class ProductsInRange
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = 
                CultureInfo.InvariantCulture;

            var products = new OrderedMultiDictionary<decimal, string>(false);

            int productsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < productsCount; i++)
            {
                string[] input = Console.ReadLine().Trim().Split();

                string product = input[0];
                decimal price = decimal.Parse(input[1]);

                products[price].Add(product);
            }

            string[] ranges = Console.ReadLine().Trim().Split();
            decimal from = decimal.Parse(ranges[0]);
            decimal to = decimal.Parse(ranges[1]);

            Console.WriteLine();
            Console.WriteLine("Products in price range [{0} - {1}]:\n", from, to);
            var productsInRange = products.Range(from, true, to, true);
            foreach (var product in productsInRange)
            {
                Console.Write(product.Key + " - ");
                Console.WriteLine(string.Join(", ", product.Value));
            }
        }
    }
}