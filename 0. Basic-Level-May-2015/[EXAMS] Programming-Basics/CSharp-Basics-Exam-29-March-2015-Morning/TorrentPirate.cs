using System;

class TorrentPirate //-k.d
{
    static void Main()
    {
        decimal megabytesToDownload = decimal.Parse(Console.ReadLine());
        decimal cinemaTicketPrice = decimal.Parse(Console.ReadLine());
        decimal wifeSpending = decimal.Parse(Console.ReadLine());

        decimal downloadTime = megabytesToDownload / 2 / 60 / 60;
        decimal mallPrice = downloadTime * wifeSpending;
        decimal numberOfMovies = megabytesToDownload / 1500;
        decimal cinemaPrice = (decimal)numberOfMovies * cinemaTicketPrice;

        if (cinemaPrice < mallPrice)
        {
            Console.WriteLine("cinema -> {0:F2}lv", cinemaPrice);
        }
        else
        {
            Console.WriteLine("mall -> {0:F2}lv", mallPrice);
        }
    }
}