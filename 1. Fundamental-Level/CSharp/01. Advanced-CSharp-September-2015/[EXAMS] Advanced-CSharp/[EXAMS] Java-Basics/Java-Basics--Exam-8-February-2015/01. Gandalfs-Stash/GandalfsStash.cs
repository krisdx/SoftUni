using System;

class GandalfsStash
{
    static void Main()
    {
        int happinessLevel = int.Parse(Console.ReadLine());
        string[] foods = Console.ReadLine().ToLower().Split(new char[] { ' ', '\t', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=', '_', ';', ',', '~', '/', '\\', '\r', '?', '<', '>', ':', '{', '}', '[', ']', '|', '`', '.'}, StringSplitOptions.RemoveEmptyEntries);

        happinessLevel = Eat(foods, happinessLevel);
        
        PrintHappinessLevel(happinessLevel);
    }

    static int Eat(string[] foods, int happinessLevel)
    {
        for (int i = 0; i < foods.Length; i++)
        {
            switch (foods[i])
            {
                case "cram": happinessLevel += 2; break;
                case "lembas": happinessLevel += 3; break;
                case "apple": happinessLevel += 1; break;
                case "melon": happinessLevel += 1; break;
                case "honeycake": happinessLevel += 5; break;
                case "mushrooms": happinessLevel -= 10; break;
                default: happinessLevel -= 1; break;
            }
        }

        return happinessLevel;
    }

    static void PrintHappinessLevel(int happinessLevel)
    {
        if (happinessLevel < -5)
        {
            Console.WriteLine("{0}\nAngry", happinessLevel);
        }
        else if (happinessLevel >= -5 && happinessLevel < 0)
        {
            Console.WriteLine("{0}\nSad", happinessLevel);
        }
        else if (happinessLevel >= 0 && happinessLevel <= 15)
        {
            Console.WriteLine("{0}\nHappy", happinessLevel);
        }
        else if (happinessLevel > 15)
        {
            Console.WriteLine("{0}\nSpecial JavaScript mood", happinessLevel);
        }
    }
}