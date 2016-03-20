using System;
using System.Collections.Generic;

public class CustomLINQExtensionMethods
{
    public static void Main()
    {
        // First task
        IList<string> strings = new List<string>();
        for (int i = 1; i <= 10; i++)
        {
            char symbol = (char)('a' - 1 + i);
            int symbolCount = i * 2;

            strings.Add(new string(symbol, symbolCount));
        }

        var filterStrings = 
            strings.WhereNot(str => str.Length >= 10);
        foreach (var str in filterStrings)
        {
            Console.WriteLine(str);
        }

        // Second task
        IList<Person> students = new List<Person>();
        students.Add(new Person("Pesho", 18));
        students.Add(new Person("Gosho", 25));

        var oldestAge = 
            students.Max(person => person.Age);
        Console.WriteLine("\nOldest age: " + oldestAge);

    }
}