using System;

class WineGlass //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int dotsCount = 0;
        int middleAsterisk = n - 2;

        for (int i = 0; i < n; i++)
        {
           // The upper part of the glass
            if (i < n / 2) 
            {
                string dots = new string('.', dotsCount);
                string asterisk = new string('*', middleAsterisk);
                Console.WriteLine(dots + "\\" + asterisk + "/" + dots);
                dotsCount++;
                middleAsterisk -= 2;
            }
            // The middle part of the glasss
            else if (n < 12 && i < n -1 || n >= 12 && i < n - 2)
            {
                string dots = new string('.', (n / 2) - 1);
                Console.WriteLine(dots + '|' + '|' +  dots);
            }
            else
            {
                Console.WriteLine(new string('-', n));
            }
        }
    }
}
