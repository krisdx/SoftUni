using System;

class TimeSpan
{
    static void Main()
    {
        string[] start = Console.ReadLine().Split(':');
        string[] end = Console.ReadLine().Split(':');

        ulong totalSecond =
            (ulong.Parse(start[0]) * 3600 +
            ulong.Parse(start[1]) * 60 +
            ulong.Parse(start[2])) -
            (ulong.Parse(end[0]) * 3600 +
            ulong.Parse(end[1]) * 60 +
            ulong.Parse(end[2]));

        Console.WriteLine("{0}:{1:00}:{2:00}", totalSecond / 3600, (totalSecond % 3600) / 60, totalSecond % 60);
    }
}