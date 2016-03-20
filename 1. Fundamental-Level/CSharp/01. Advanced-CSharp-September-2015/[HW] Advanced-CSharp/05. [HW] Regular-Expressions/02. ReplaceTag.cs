using System;
using System.Text.RegularExpressions;

// Write a program that replaces in a HTML document given as string all the tags <a href=…>…</a> with corresponding tags [URL href=…]…[/URL]. Print the result on the console.

class ReplaceTag
{
    static void Main()
    {
        // The input must be on one line !

        string inputHTML = Console.ReadLine();
        string outputHTML = Regex.Replace(inputHTML,
                         @"<a.*href=(\w+:\/\/\w+\.\w+)(?:>)(\w+)<\/a>",
                         @"[URL href=$1]$2[/URL]");

        Console.WriteLine(outputHTML);
    }
}