using System;

public class SudokuResults
{
    public static void Main()
    {
        long totalSeconds = 0;
        int gamesCount = 0;
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "Quit")
            {
                break;
            }

            string[] lineDetails = line.Split(':');
            int minutes = int.Parse(lineDetails[0]);
            int seconds = int.Parse(lineDetails[1]);

            totalSeconds += (minutes * 60) + seconds;

            gamesCount++;
        }

        double averageTimeInSeconds = (double)totalSeconds / gamesCount;
        if (averageTimeInSeconds < 720)
        {
            Console.WriteLine("Gold Star");
        }
        else if (averageTimeInSeconds >= 720 && averageTimeInSeconds <= 1440)
        {
            Console.WriteLine("Silver Star");
        }
        else
        {
            Console.WriteLine("Bronze Star");
        }

        Console.WriteLine(@"Games - {0} \ Average seconds - {1}", gamesCount, Math.Ceiling(averageTimeInSeconds));
    }
}