using System;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace Orders
{
    public class OrdersMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var data = new DataMapper();
            var allCategories = data.GetAllCategories();
            var allProducts = data.GetAllProducts();
            var allOrders = data.GetAllOrders();

            var firstFiveMostExpensiveProducts = allProducts
                .OrderByDescending(product => product.UnitPrice)
                .Take(5)
                .Select(product => product.Name);
            Console.WriteLine(string.Join(Environment.NewLine, firstFiveMostExpensiveProducts));

            Console.WriteLine(new string('-', 10));

            var numberOfProductsInEachCategory = allProducts
                .GroupBy(product => product.CategoryId)
                .Select(group => new 
                { 
                    Category = allCategories.First(c => c.Id == group.Key).Name,
                    Count = group.Count() 
                })
                .ToList();
            foreach (var product in numberOfProductsInEachCategory)
            {
                Console.WriteLine("{0}: {1}", product.Category, product.Count);
            }

            Console.WriteLine(new string('-', 10));

            var topFiveOrderedProducts = allOrders
                .GroupBy(order => order.ProductId)
                .Select(group => new
                {
                    Product = allProducts.First(p => p.Id == group.Key).Name,
                    Quantities = group.Sum(grp => grp.Quantity)
                })
                .OrderByDescending(q => q.Quantities)
                .Take(5);
            foreach (var product in topFiveOrderedProducts)
            {
                Console.WriteLine("{0}: {1}", product.Product, product.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            var mostProfitableCategory = allOrders
                .GroupBy(order => order.ProductId)
                .Select(group => new
                {
                    catId = allProducts.First(p => p.Id == group.Key).CategoryId,
                    price = allProducts.First(p => p.Id == group.Key).UnitPrice,
                    quantity = group.Sum(p => p.Quantity)
                })
                .GroupBy(group => group.catId)
                .Select(group => new
                {
                    categoryName = allCategories.First(c => c.Id == group.Key).Name,
                    totalQuantity = group.Sum(g => g.quantity * g.price)
                })
                .OrderByDescending(group => group.totalQuantity)
                .First();
            Console.WriteLine("{0}: {1}", mostProfitableCategory.categoryName, mostProfitableCategory.totalQuantity);
        }
    }
}