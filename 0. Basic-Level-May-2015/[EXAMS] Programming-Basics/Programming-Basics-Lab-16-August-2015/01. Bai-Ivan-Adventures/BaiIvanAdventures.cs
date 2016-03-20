using System;

class BaiIvanAdventures
{
    static void Main()
    {
        int dayOfWeek = int.Parse(Console.ReadLine());
        decimal money = decimal.Parse(Console.ReadLine());
        decimal desiredAmountOfAlcohol = decimal.Parse(Console.ReadLine());

        decimal canAffort = 0;
        switch (dayOfWeek)
        {
            case 0: canAffort = money / 25; break;
            case 1: canAffort = money / 21; break;
            case 2: canAffort = money / 14; break;
            case 3: canAffort = money / 17; break;
            case 4: canAffort = money / 45; break;
            case 5: canAffort = money / 59; break;
            case 6: canAffort = money / 42; break;
        }

        string condition = CheckCondition(canAffort);


        if (canAffort < desiredAmountOfAlcohol)
        {
            Console.WriteLine("Bai Ivan is {0} and quite sad. He wanted to drink another {1:f2} l. of alcohol", condition,  desiredAmountOfAlcohol - canAffort);
        }
        else if (canAffort > desiredAmountOfAlcohol)
        {
            Console.WriteLine("Bai Ivan is {0} and very happy and he shared {1:f2} l. of alcohol with his friends", condition, canAffort - desiredAmountOfAlcohol);
        }
        else if (canAffort == desiredAmountOfAlcohol)
        {
            Console.WriteLine("Bai Ivan is {0} and happy. He is as drunk as he wanted", condition);
        }
    }

    public static string CheckCondition(decimal canAffort)
    {
        if (canAffort > 1.5m)
        {
            return "very drunk";
        }
        else if (canAffort >= 1 && canAffort <= 1.5m)
        {
            return "drunk";
        }
        else 
        {
            return "sober";
        }
    }
}