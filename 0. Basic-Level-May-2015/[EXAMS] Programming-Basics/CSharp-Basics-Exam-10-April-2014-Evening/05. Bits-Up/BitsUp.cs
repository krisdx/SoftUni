using System;

class BitsUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int index = 0;
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int k = 0; k < 8; k++)
            {
                if (index % step == 1 || 
                    (step == 1 && index > 0)) // if we have to switch evert bit
                {
                    number |= 1 << (7 - k);
                }
                index++;
            }

            Console.WriteLine(number);
        }
    }
}