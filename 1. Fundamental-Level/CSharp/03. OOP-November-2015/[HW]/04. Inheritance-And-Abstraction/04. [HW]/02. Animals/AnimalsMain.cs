using System;
using System.Collections.Generic;
using System.Linq;

public class AnimalsMain
{
    public static void Main()
    {
        var animals = new List<Animal>
        {
            new Tomcat("Ivo", 4),
            new Tomcat("Ivan", 3),
            new Cat("Mariq", 3, "Idealna"),
            new Cat("Stefi", 1, "Prevusohdna"),
            new Kitten("Sashka", 10),
            new Kitten("Sahara", 6),
            new Frog ("Gosho", 1, "male"),
            new Frog ("Pesho", 2, "male"),
            new Dog("Stamat", 7, "male"),
            new Dog ("Lili", 8, "female")
        };

        double averageAgeOfDogs =
            animals.FindAll(x => x is Dog)
            .Average(x => x.Age);
        double averageAgeOfFrogs =
            animals.FindAll(x => x is Frog)
            .Average(x => x.Age);
        double averageAgeOfTomcats =
            animals.FindAll(x => x is Tomcat)
            .Average(x => x.Age);
        double averageAgeOfKittens =
            animals.FindAll(x => x is Kitten)
            .Average(x => x.Age);
        double averageAgeOfCats =
            animals.FindAll(x => x is Cat)
            .Average(x => x.Age);

        Console.WriteLine("Average age of animals: ");
        Console.WriteLine("Dogs: {0}", averageAgeOfDogs);
        Console.WriteLine("Frogs: {0}", averageAgeOfFrogs);
        Console.WriteLine("Cats: {0}", averageAgeOfCats);
        Console.WriteLine("Kittens: {0}", averageAgeOfKittens);
        Console.WriteLine("Tomcats: {0}", averageAgeOfTomcats);
    }
}