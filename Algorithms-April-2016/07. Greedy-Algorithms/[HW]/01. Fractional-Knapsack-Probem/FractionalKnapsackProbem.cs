namespace FractionalKnapsackProbem
{
    using System;
    using System.Collections.Generic;

    public class FractionalKnapsackProbem
    {
        public static void Main()
        {
            var items = new SortedSet<Item>();

            int capacity = int.Parse(Console.ReadLine().Split(':')[1].Trim());
            int itemsCount = int.Parse(Console.ReadLine().Split(':')[1].Trim());
            for (int i = 0; i < itemsCount; i++)
            {
                string[] lineArgs = Console.ReadLine()
                    .Split(new char[] { '-', '>', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                double price = double.Parse(lineArgs[0]);
                double weight = double.Parse(lineArgs[1]);
                var item = new Item(price, weight);
                items.Add(item);
            }

            double totalPrice = 0;
            double totalWeight = 0;
            foreach (var item in items)
            {
                if (totalWeight >= capacity)
                {
                    break;
                }

                if (totalWeight + item.Weight > capacity)
                {
                    // Take piece of item
                    double weightToTake = capacity - totalWeight;
                    totalWeight += weightToTake;
                    double percentageTaken = (weightToTake / item.Weight) * 100;
                    totalPrice += item.Price * (percentageTaken / 100);
                    Console.WriteLine("Take {0:f2}% of item with price {1:f2} and weight {2:f2}",
                         percentageTaken, item.Price, item.Weight);
                }
                else
                {
                    // Take item full price and weight.
                    totalPrice += item.Price;
                    totalWeight += item.Weight;
                    Console.WriteLine("Take 100% of item with price {0:f2} and weight {1:f2}",
                        item.Price, item.Weight);
                }
            }

            Console.WriteLine("Total price: {0:f2}", totalPrice);
        }
    }
}