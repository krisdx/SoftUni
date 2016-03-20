using System;

public class PersonsMain
{
    public static void Main()
    {
        Person firstPerson = new Person("Pesho", 28);
        Console.WriteLine(firstPerson);

        Person secondPerson = new Person("Gosho", 35, "gosh@gmail.com");
        Console.WriteLine(secondPerson);
    }
}