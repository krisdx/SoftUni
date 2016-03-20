using System;

class Diamonds // -k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int sidedashesCounter = n / 2;
        int middleDashesCounter = 1;
        for (int i = 0; i < n / 2; i++)
        {
            string sideDashes = new string('-', sidedashesCounter);
            string middleDashes = new string('-', middleDashesCounter);
            if (i == 0)
            {
                Console.WriteLine(sideDashes +  '*' + sideDashes);
                sidedashesCounter--;
            }
            else
            {
                Console.WriteLine(sideDashes + '*' + middleDashes + '*' + sideDashes);
                sidedashesCounter--;
                middleDashesCounter += 2;
            }
        }

        Console.WriteLine('*' + new string('-', middleDashesCounter) + '*');

        sidedashesCounter = 1;
        middleDashesCounter -= 2;
        for (int i = n / 2 - 1; i > 0; i--)
        {
            string sideDashes = new string('-', sidedashesCounter);
            string middleDashes = new string('-', middleDashesCounter);

                Console.WriteLine(sideDashes + '*' + middleDashes + '*' + sideDashes);
                sidedashesCounter++;
                middleDashesCounter -= 2;
        }

        Console.WriteLine(new string('-', n / 2) + '*' + new string('-', n / 2));
    }
}