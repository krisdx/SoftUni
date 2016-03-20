using System;

public class ValidPersonMain
{
    public static void Main()
    {
        // Valid person
        Person person = new Person("Pesho", "Peshev", 19);
        Console.WriteLine("{0}\n", person);

        // Invalid persons
        try
        {
            Person person2 = new Person("Gosho", "Georgiev", 123);
        }
        catch (ArgumentNullException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            Console.WriteLine(exception.Message);
        }

        Console.WriteLine();

        try
        {
            Person person3 = new Person(string.Empty, "Petrov", 30);
        }
        catch (ArgumentNullException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            Console.WriteLine(exception.Message);
        }

        Console.WriteLine();

        try
        {
            Person person4 = new Person("Ivan", "Ivanov", -3);
        }
        catch (ArgumentNullException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}