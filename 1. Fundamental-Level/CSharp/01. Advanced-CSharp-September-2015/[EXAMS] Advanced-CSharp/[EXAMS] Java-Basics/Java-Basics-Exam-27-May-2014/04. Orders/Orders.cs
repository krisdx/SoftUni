using System;
using System.Collections.Generic;

class Orders
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, SortedDictionary<string, int>> orders = new Dictionary<string, SortedDictionary<string, int>>();
        for (int i = 0; i < n; i++)
        {
            string[] order = Console.ReadLine().Trim().Split();

            string name = order[0];
            int amount = int.Parse(order[1]);
            string product = order[2];

            if (orders.ContainsKey(product))
            {
                if (orders[product].ContainsKey(name))
                {
                    orders[product][name] += amount;
                }
                else
                {
                    orders[product].Add(name, amount);
                }
            }
            else
            {
                SortedDictionary<string, int> newOrder = new SortedDictionary<string,int>
                {
                    { name , amount }
                };
                orders.Add(product, newOrder);
            }
        }

        foreach (var product in orders)
        {
            Console.Write("{0}: ", product.Key);
            int length = product.Value.Count;
            int counter = 0;
            foreach (var name in product.Value)
            {
                counter++;
                if (counter != length)
                {
                    
                Console.Write("{0} {1}, ", name.Key, name.Value);
                }
                else
                {
                    Console.Write("{0} {1}", name.Key, name.Value);
                }
            }
            Console.WriteLine();
        }
    }
}