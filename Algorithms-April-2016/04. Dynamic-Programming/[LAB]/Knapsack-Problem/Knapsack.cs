﻿namespace Knapsack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Knapsack
    {
        public static void Main()
        {
            var items = new[]
            {
                new Item { Weight = 5, Price = 30 },
                new Item { Weight = 8, Price = 120 },
                new Item { Weight = 7, Price = 10 },
                new Item { Weight = 0, Price = 20 },
                new Item { Weight = 4, Price = 50 },
                new Item { Weight = 5, Price = 80 },
                new Item { Weight = 2, Price = 10 }
            };

            var knapsackCapacity = 20;

            var itemsTaken = FillKnapsack(items, knapsackCapacity);

            Console.WriteLine("Knapsack weight capacity: {0}", knapsackCapacity);
            Console.WriteLine("Take the following items in the knapsack:");
            foreach (var item in itemsTaken)
            {
                Console.WriteLine(
                    "  (weight: {0}, price: {1})",
                    item.Weight,
                    item.Price);
            }

            Console.WriteLine("Total weight: {0}", itemsTaken.Sum(i => i.Weight));
            Console.WriteLine("Total price: {0}", itemsTaken.Sum(i => i.Price));
        }

        public static Item[] FillKnapsack(Item[] items, int capacity)
        {
            var maxPrice = new int[items.Length, capacity + 1];
            var isItemTaken = new bool[items.Length, capacity + 1];

            for (int c = 0; c <= capacity; c++)
            {
                if (items[0].Weight <= c)
                {
                    maxPrice[0, c] = items[0].Price;
                    isItemTaken[0, c] = true;
                }
            }

            for (int i = 1; i < items.Length; i++)
            {
                for (int c = 0; c <= capacity; c++)
                {
                    // Assuming that we haven't taken the current item and 
                    // the price stays the same.
                    maxPrice[i, c] = maxPrice[i - 1, c];

                    int remainingCapacity = c - items[i].Weight;
                    if (remainingCapacity >= 0 &&
                        maxPrice[i - 1, remainingCapacity] + items[i].Price > maxPrice[i, c])
                    {
                        maxPrice[i, c] = maxPrice[i - 1, remainingCapacity] + items[i].Price;
                        isItemTaken[i, c] = true;
                    }
                }
            }

            // Retrace
            var itemsTaken = new List<Item>();
            int index = items.Length - 1;
            while (index >= 0)
            {
                if (isItemTaken[index, capacity])
                {
                    itemsTaken.Add(items[index]);
                    capacity -= items[index].Weight;
                }

                index--;
            }

            itemsTaken.Reverse();
            return itemsTaken.ToArray();
        }
    }
}