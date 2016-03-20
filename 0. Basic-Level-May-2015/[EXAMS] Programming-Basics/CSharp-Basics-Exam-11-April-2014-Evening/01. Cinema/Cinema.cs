using System;

class Cinema //-k.d
{
    static void Main()
    {
        string typeOfProjection = Console.ReadLine();
        float rows = float.Parse(Console.ReadLine());
        float columns = float.Parse(Console.ReadLine());

        float income = 0;

        if (typeOfProjection == "Premiere")
        {
            income += 12;
        }
        else if (typeOfProjection == "Normal")
        {
            income += 7.5f;
        }
        else 
        {
            income += 5;
        }

        income = income * (columns * rows);
        Console.WriteLine("{0:f2} leva", income);
    }
}