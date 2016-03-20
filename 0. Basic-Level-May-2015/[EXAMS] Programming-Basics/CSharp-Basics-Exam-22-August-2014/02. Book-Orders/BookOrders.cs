using System;

class BookOrders //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        decimal bookInPacket = 0;
        decimal totalBooks = 0;
        decimal totoalPrice = 0;
        for (int book = 0; book < n; book++)
        {
            decimal numberOfPackest = decimal.Parse(Console.ReadLine());
            decimal bookPerPacket = decimal.Parse(Console.ReadLine());
            decimal bookPrice = decimal.Parse(Console.ReadLine());

            bookInPacket = (bookPerPacket * numberOfPackest);
            bookPrice = GetDisCount(bookPrice, numberOfPackest);
            totoalPrice += bookInPacket * bookPrice;
            totalBooks += bookInPacket;
        }

        Console.WriteLine(totalBooks);
        Console.WriteLine("{0:F2}", totoalPrice);
    }

    private static decimal GetDisCount(decimal bookPrice, decimal numberOfPackest)
    {
        if (numberOfPackest < 10)
        {
            return bookPrice;
        }
        if (numberOfPackest >= 10 && numberOfPackest <= 19)
        {
            bookPrice = bookPrice - (bookPrice *  0.05m);
        }
        else if (numberOfPackest >= 20 && numberOfPackest <= 29)
        {
            bookPrice = bookPrice - (bookPrice * 0.06m);
        }
        else if (numberOfPackest >= 30 && numberOfPackest <= 39)
        {
            bookPrice = bookPrice - (bookPrice * 0.07m);
        }
        else if (numberOfPackest >= 40 && numberOfPackest <= 49)
        {
            bookPrice = bookPrice - (bookPrice * 0.08m);
        }
        else if (numberOfPackest >= 50 && numberOfPackest <= 59)
        {
            bookPrice = bookPrice - (bookPrice * 0.09m);
        }
        else if (numberOfPackest >= 60 && numberOfPackest <= 69)
        {
            bookPrice = bookPrice - (bookPrice * 0.1m);
        }
        else if (numberOfPackest >= 70 && numberOfPackest <= 79)
        {
            bookPrice = bookPrice - (bookPrice * 0.11m);
        }
        else if (numberOfPackest >= 80 && numberOfPackest <= 89)
        {
            bookPrice = bookPrice - (bookPrice * 0.12m);
        }
        else if (numberOfPackest >= 90 && numberOfPackest <= 99)
        {
            bookPrice = bookPrice - (bookPrice * 0.13m);
        }
        else if (numberOfPackest >= 100 && numberOfPackest <= 109)
        {
            bookPrice = bookPrice - (bookPrice * 0.14m);
        }
        else if (numberOfPackest > 110) 
        {
            bookPrice = bookPrice - (bookPrice * 0.15m);
        }

        return bookPrice;
    }
}