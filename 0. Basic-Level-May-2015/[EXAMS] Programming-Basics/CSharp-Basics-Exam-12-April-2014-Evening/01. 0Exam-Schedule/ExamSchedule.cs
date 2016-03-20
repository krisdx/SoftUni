using System;

class ExamSchedule //-k.d
{
    static void Main()
    {
        int startHour = int.Parse(Console.ReadLine());
        int startMinutes = int.Parse(Console.ReadLine());
        string partOfTheDay = Console.ReadLine();
        int durationHours = int.Parse(Console.ReadLine());
        int durationMinutes = int.Parse(Console.ReadLine());
        if (partOfTheDay == "PM")
        {
            startHour += 12;
        }

        DateTime examStart = new DateTime(2015, 01, 01);
        examStart = examStart.AddHours(startHour).AddMinutes(startMinutes);

        DateTime examEnd = examStart.AddHours(durationHours).AddMinutes(durationMinutes);
        Console.WriteLine("{0:hh:mm:tt}", examEnd);
    }
}