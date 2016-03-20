using System;
using System.Collections.Generic;

class OfficeStuff
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        SortedDictionary<string, Dictionary<string, int>> officeStuff = new SortedDictionary<string, Dictionary<string, int>>();
        for (int i = 0; i < n; i++)
        {
            string[] officeStuffDetails = Console.ReadLine().Split(new char[] { '|', ' ', '\t', '-' }, StringSplitOptions.RemoveEmptyEntries);
            string companyName = officeStuffDetails[0];
            string product = officeStuffDetails[2];
            int amount = int.Parse(officeStuffDetails[1]);

            if (officeStuff.ContainsKey(companyName))
            {
                if (officeStuff[companyName].ContainsKey(product))
                {
                    officeStuff[companyName][product] += amount;
                }
                else
                {
                    officeStuff[companyName].Add(product, amount);
                }
            }
            else
            {
                Dictionary<string, int> productAndAmount = new Dictionary<string, int>{
                    {product, amount}
                };
                officeStuff.Add(companyName, productAndAmount);
            }
        }

        Print(officeStuff);
    }

    static void Print(SortedDictionary<string, Dictionary<string, int>> officeStuff)
    {
        foreach (var company in officeStuff)
        {
            Console.Write("{0}: ", company.Key);
            int length = company.Value.Count;
            int counter = 1;
            foreach (var productAndAmount in company.Value)
            {
                if (counter != length)
                {
                    Console.Write("{0}-{1}, ", productAndAmount.Key, productAndAmount.Value);
                }
                else
                {
                    Console.WriteLine("{0}-{1}", productAndAmount.Key, productAndAmount.Value);
                }

                counter++;
            }
        }
    }
}