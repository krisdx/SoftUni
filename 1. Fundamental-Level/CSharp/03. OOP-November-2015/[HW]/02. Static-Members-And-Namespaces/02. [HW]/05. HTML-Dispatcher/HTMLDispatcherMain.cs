using System;

public class HTMLDispatcherMain
{
    public static void Main()
    {
        ElementBuilder div = new ElementBuilder("div");
        div.AddAttribute("id", "page");
        div.AddAttribute("class", "big");
        div.AddContent("<p>Hello</p>");
        Console.WriteLine(div * 2);
        Console.WriteLine();

        string image = HTMLDispatcher.CreateImage("c://image.jpg", "Picture", "Image");
        string URL = HTMLDispatcher.CreateURL("www.gmail.com", "Gmail", "gmail.com is awsome.");
        string input = HTMLDispatcher.CreateInput("text", "username", "user");

        Console.WriteLine(URL);
        Console.WriteLine(image);
        Console.WriteLine(input);
    }
}