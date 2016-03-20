using System;
using System.Collections.Generic;

class Nuts
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        SortedDictionary<string, Dictionary<string, int>> companies = new SortedDictionary<string, Dictionary<string, int>>();
        for (int i = 0; i < n; i++)
        {
            string[] companyNutsAmountDetails = Console.ReadLine().Split();
            string companyName = companyNutsAmountDetails[0];
            string product = companyNutsAmountDetails[1];
            int amount = GetAmount(companyNutsAmountDetails[2]);

            if (companies.ContainsKey(companyName))
            {
                if (companies[companyName].ContainsKey(product))
                {
                    companies[companyName][product] += amount;
                }
                else
                {
                    companies[companyName].Add(product, amount);
                }
            }
            else
            {
                Dictionary<string, int> productAndAmount = new Dictionary<string, int>(){
                    {product, amount}
                };
                companies.Add(companyName, productAndAmount);
            }
        }

        Print(companies);
    }

    static int GetAmount(string amount)
    {
        amount = amount.Remove(amount.Length - 1);
        amount = amount.Remove(amount.Length - 1);

        return int.Parse(amount);
    }

    static void Print(SortedDictionary<string, Dictionary<string, int>> companies)
    {
        foreach (var company in companies)
        {
            Console.Write("{0}: ", company.Key);
            int length = company.Value.Count;
            int counter = 1;
            foreach (var productAndAmount in company.Value)
            {
                if (counter != length)
                {
                    Console.Write("{0}-{1}kg, ", productAndAmount.Key, productAndAmount.Value);
                }
                else
                {
                    Console.Write("{0}-{1}kg", productAndAmount.Key, productAndAmount.Value);
                }
                counter++;
            }
            Console.WriteLine();
        }
    }
}