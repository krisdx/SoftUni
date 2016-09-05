using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestLecturesSchedule
{
    using System;

    public class BestLecturesSchedule
    {
        public static void Main()
        {
            var lectures = new SortedSet<Lecture>();

            int lecturesCount = int.Parse(Console.ReadLine().Split(':')[1].Trim());
            for (int i = 0; i < lecturesCount; i++)
            {
                string[] lineArgs = Console.ReadLine()
                 .Split(new string[] { " - ", ": " },
                 StringSplitOptions.RemoveEmptyEntries);
                string lectureName = lineArgs[0];
                int start = int.Parse(lineArgs[1]);
                int end = int.Parse(lineArgs[2]);
                var lecture = new Lecture(lectureName, start, end);
                lectures.Add(lecture);
            }

            var output = new StringBuilder();

            var latestLecture = lectures.First();
            output.AppendLine(latestLecture.ToString());
            int totalLectures = 1;
            foreach (var lecture in lectures)
            {
                if (lecture.StartTime > latestLecture.EndTime)
                {
                    output.AppendLine(lecture.ToString());
                    latestLecture = lecture;
                    totalLectures++;
                }
            }

            Console.WriteLine("Lectures ({0}):", totalLectures);
            Console.WriteLine(output.ToString().Trim());
        }
    }
}