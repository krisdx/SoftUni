using System;

class VideoDurations
{
    static void Main()
    {
        string inputHours = Console.ReadLine();

        int totalMinutes = 0;
        while (inputHours != "End")
        {
            string[] hourDetails = inputHours.Split(':');
            int hours = int.Parse(hourDetails[0]);
            int minutes = int.Parse(hourDetails[1]);

            totalMinutes += hours * 60;
            totalMinutes += minutes;

            inputHours = Console.ReadLine();
        }

        Console.WriteLine("{0}:{1:00}", totalMinutes / 60, totalMinutes % 60);
    }
}