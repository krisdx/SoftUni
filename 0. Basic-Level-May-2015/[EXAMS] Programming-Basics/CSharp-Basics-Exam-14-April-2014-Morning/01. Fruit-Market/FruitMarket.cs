using System;

class FruitMarket
{
    static void Main() //-k.d
    {
        string dayOfWeek = Console.ReadLine();
        decimal quantity1 = decimal.Parse(Console.ReadLine());
        string product1 = Console.ReadLine();
        decimal quantity2 = decimal.Parse(Console.ReadLine());
        string product2 = Console.ReadLine();
        decimal quantity3 = decimal.Parse(Console.ReadLine());
        string product3 = Console.ReadLine();

        decimal firstProduct = GetPrice(dayOfWeek, product1);
        decimal secondProduct = GetPrice(dayOfWeek, product2);
        decimal thirdProduct = GetPrice(dayOfWeek, product3);

        decimal totalPrice = (quantity1 * firstProduct) + (quantity2 * secondProduct) + (quantity3 * thirdProduct);

        Console.WriteLine("{0:F2}", totalPrice);
    }

    private static decimal GetPrice(string dayOfWeek, string product)
    {
        bool isFruit = false;

        decimal price = 0;
        switch (product)
        {
            case "banana": price = 1.8m; isFruit = true;  break;
            case "cucumber": price = 2.75m; break;
            case "tomato": price = 3.2m; break;
            case "orange": price = 1.6m; isFruit = true; break;
            case "apple": price = 0.86m; isFruit = true; break;
        }

        switch (dayOfWeek)
        {
            case "Friday": price = price * 0.90m; break;
            case "Sunday": price = price * 0.95m; break;
            case "Tuesday": if (isFruit) price = price * 0.80m; break;
            case "Wednesday": if (!isFruit) price = price * 0.90m; break;
            case "Thursday": if (product == "banana") price = price * 0.70m; break;       
        }
        return price;
    }
}