using System;

class Nums //-k.d
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        for (int num = a; num <= b; num++)
        {
            bool isEven = (num & 1) == 0;
            if (isEven)
            {
                Console.WriteLine("{0:F3}", Math.Sqrt(num));
            }
            else
            {
                Console.WriteLine("{0:f3}", Math.Pow(num, 2));
            }
        }
    }
}