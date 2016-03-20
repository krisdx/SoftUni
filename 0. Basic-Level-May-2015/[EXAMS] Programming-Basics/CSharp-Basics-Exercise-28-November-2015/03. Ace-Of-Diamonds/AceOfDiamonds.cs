using System;

public class AceOfDiamonds
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('*', n));

        bool hasReachedMiddle = false;

        int middleSignCounter = 1;
        int sideDashesCounter = (n - 2 - middleSignCounter) / 2;
        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine(string.Format("*{0}{1}{0}*",
                new string('-', sideDashesCounter), new string('@', middleSignCounter)));

            if (!hasReachedMiddle)
            {
                middleSignCounter += 2;
                sideDashesCounter = 
                    sideDashesCounter - 1 <= 0 ? 0 : sideDashesCounter - 1;
            }
            else
            {
                sideDashesCounter++;
                middleSignCounter = 
                    middleSignCounter - 2 <= 0 ? 0 : middleSignCounter - 2;
            }

            if (sideDashesCounter <= 0)
            {
                hasReachedMiddle = true;
            }
        }
        
        Console.WriteLine(new string('*', n));
    }
}