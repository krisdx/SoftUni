namespace CollectionOfProducts
{
    using System;
    using System.Diagnostics;

    public class CollectionOfProductsExample
    {
        private static readonly Random randomGenerator = new Random();

        public static void Main()
        {
            var collectionOfProducts = new CollectionOfProducts();

            var stopWatch = new Stopwatch();

            int numberOfProductsAdded = 50000;
            stopWatch.Start();
            for (int i = 0; i <= numberOfProductsAdded; i++)
            {
                var param = i.ToString();
                collectionOfProducts.Add(param, param, param, i);
            }
            stopWatch.Stop();
            Console.WriteLine("Added {0} products in: {1}", numberOfProductsAdded, stopWatch.Elapsed);

            Console.WriteLine(collectionOfProducts);

            stopWatch.Restart();
            for (int i = 0; i <= numberOfProductsAdded; i++)
            {
                var param = i.ToString();
                int randomNum = randomGenerator.Next(0, numberOfProductsAdded);

                var productsByTitle = collectionOfProducts.FindProductsByTitle(param);
                var productsByTitleAndPrice = collectionOfProducts.FindProductsByTitleAndPrice(param, i);
                var productsByTitleAndPriceRange = collectionOfProducts.FindProductsByTitleAndPriceRange(param, 0, randomNum);
                var productsBySupplierAndPrice = collectionOfProducts.FindProductsBySupplierAndPrice(param, i);
                var productsBySupplierAndPriceRange = collectionOfProducts.FindProductsBySupplierAndPriceRange(param, 0, randomNum);
                var productsInPriceRange = collectionOfProducts.FindProductsInPriceRange(0, randomNum);
            }
            stopWatch.Stop();
            Console.WriteLine("All 6 find operations, executed {0} times: {1}", numberOfProductsAdded, stopWatch.Elapsed);

            stopWatch.Restart();
            for (int i = numberOfProductsAdded; i >= 0; i--)
            {
                var id = i.ToString();
                collectionOfProducts.Remove(id);
            }
            stopWatch.Stop();
            Console.WriteLine("Removing all {0} products in: {1}", numberOfProductsAdded, stopWatch.Elapsed);
        }
    }
}