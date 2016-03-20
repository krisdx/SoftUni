using System;

class Headphones
{
    static void Main() //-k.d
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n + 1; i++)
        {
            string dashes = new string('-', n / 2);
            string middleDashes = new string('-', n);
            if (i == 0)
            {
                Console.WriteLine(dashes + new string('*', n + 2) + dashes);
            }
            else
            {
                Console.WriteLine(dashes + '*' + middleDashes + '*' + dashes);
            }
        }

        int sideDasheCounter = n / 2 - 1;
        int asteriskCounter = 3;
        int middleDashesCounter = n - 2;
        for (int i = 0; i < n / 2; i++)
        {
            string sideDashes = new string('-', sideDasheCounter);
            string asterisk = new string('*', asteriskCounter);
            string middleDashes = new string('-', middleDashesCounter);
            Console.WriteLine(sideDashes + asterisk + middleDashes + asterisk + sideDashes);
            middleDashesCounter -= 2;
            sideDasheCounter--;
            asteriskCounter += 2;
        }

        sideDasheCounter = 1;
        asteriskCounter = n - 2;
        middleDashesCounter = 3;
        for (int i = 0; i < n / 2; i++)
        {
            string sideDashes = new string('-', sideDasheCounter);
            string asterisk = new string('*', asteriskCounter);
            string middleDashes = new string('-', middleDashesCounter);
            Console.WriteLine(sideDashes + asterisk + middleDashes + asterisk + sideDashes);
            sideDasheCounter++;
            asteriskCounter -= 2;
            middleDashesCounter += 2;
        }
    }
}