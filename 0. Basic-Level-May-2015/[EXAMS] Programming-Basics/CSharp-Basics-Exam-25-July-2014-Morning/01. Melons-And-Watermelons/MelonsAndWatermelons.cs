using System;

class MelonsAndWatermelons //-k.d
{
    static void Main()
    {
        int startDayOfWeek = int.Parse(Console.ReadLine());
        int daysDidikoEats = int.Parse(Console.ReadLine());

        int melons = 0;
        int watermelons = 0;

        for (int i = 1; i <= daysDidikoEats; i++)
        {
            switch (startDayOfWeek)
            {
                case 1: watermelons = watermelons + 1;
                    break;
                case 2: melons = melons + 2;
                    break;
                case 3: watermelons = watermelons + 1;
                    melons = melons + 1;
                    break;
                case 4: watermelons = watermelons + 2;
                    break;
                case 5: watermelons = watermelons + 2;
                    melons = melons + 2;
                    break;
                case 6: watermelons = watermelons + 1;
                    melons = melons + 2;
                    break;
            }
           
            if (startDayOfWeek >= 7)
            {
                startDayOfWeek = 1;
            }
            else
            {
                startDayOfWeek++;
            }
        }
        
        if (watermelons == melons)
        {
            Console.WriteLine("Equal amount: {0}", melons);
        }
        else
        {
            if (watermelons > melons)
            {
                Console.WriteLine("{0} more watermelons", Math.Abs(watermelons - melons));
            }
            else
            {
                Console.WriteLine("{0} more melons", Math.Abs(melons - watermelons));
            }
        }
    }
}