using System;

class TheExplorer // -k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int sideDashesCount = n / 2;
        int asteriskCount = 1;
        int middleDashesCount = 1;
        for (int i = 0; i < (n / 2); i++)
        {
            string sideDashes = new string('-', sideDashesCount);
            string asteriks = new string('*', asteriskCount);
            string middleDashes = new string('-', middleDashesCount);
            if (i == 0)
            {
                Console.WriteLine(sideDashes + asteriks + sideDashes);
                sideDashesCount--;
            }
            else
            {
                Console.WriteLine(sideDashes + asteriks + middleDashes + asteriks + sideDashes);
                sideDashesCount--;
                middleDashesCount += 2;
            }
        }
        sideDashesCount = 0;
        middleDashesCount = n - 2;
        for (int i = 0; i < (n / 2) + 1; i++)
        {
            string sideDashes = new string('-', sideDashesCount);
            string asteriks = new string('*', asteriskCount);
            string middleDashes = new string('-', middleDashesCount);

            if (i == 0)
            {
                Console.WriteLine(asteriks + middleDashes + asteriks);
                sideDashesCount++;
                middleDashesCount -= 2;
            }
            else if (i < (n / 2))
            {
                Console.WriteLine(sideDashes + asteriks + middleDashes + asteriks + sideDashes);
                sideDashesCount++;
                middleDashesCount -= 2;
                if (0 > middleDashesCount)
                {
                    middleDashesCount = middleDashesCount + 2;
                }
            }
            else
            {
                Console.WriteLine(sideDashes + asteriks + sideDashes);
            }
        }
    }
}
