using System;

// Write a program to read your birthday from the console and print how old you are now and how old you will 
// be after 10 years;

class AgeAfter10Years
{
    static void Main()
    {
        Console.Write("Write down your Birthday (YYYY.MM.DD): ");
        DateTime Birthday = DateTime.Parse(Console.ReadLine());
        DateTime Today = DateTime.Now;
        Console.WriteLine("Your age now: " + (Today.Year - Birthday.Year)); // Calculating and your current age;
        Console.WriteLine("Your age after 10 years: " + (Today.Year - Birthday.Year + 10)); // Calculating and your age after 10 years;
    }
}
