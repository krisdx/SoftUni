using System;
using System.Collections.Generic;
using System.Linq;

class CurrencyCheck
{
    static void Main() //-k.d
    {
        uint rubles = uint.Parse(Console.ReadLine());
        uint dollars = uint.Parse(Console.ReadLine());
        uint euros = uint.Parse(Console.ReadLine());
        uint websiteB = uint.Parse(Console.ReadLine());
        uint websiteM = uint.Parse(Console.ReadLine());

        double rublesPrice = Math.Round(rubles * 0.035, 3);
        double dollarsPrice = Math.Round(dollars * 1.5, 3);
        double eurosPrice = Math.Round(euros * 1.95, 3);
        double websiteBPrice = Math.Round(websiteB / 2.0, 3);
        double websiteMPrice = websiteM;

        double[] gamePrices = { rublesPrice, dollarsPrice, eurosPrice, websiteBPrice, websiteMPrice };
        List<double> pricesList = gamePrices.ToList();
        pricesList.Sort();

        Console.WriteLine("{0:F2}", pricesList[0]);
    }
}