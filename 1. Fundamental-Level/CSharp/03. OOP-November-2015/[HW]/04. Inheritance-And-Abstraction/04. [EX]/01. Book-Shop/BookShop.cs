using System;

class BookShop
{
    static void Main()
    {
        Book book = new Book("Pod Igoto", "Ivan Vazov", 15.6);
        Console.WriteLine(book);

        Console.WriteLine();

        GoldenEditionBook goldenEditionBook = new GoldenEditionBook("Tutun", "Dimitar Dimov", 22.9);
        Console.WriteLine(goldenEditionBook);
    }
}