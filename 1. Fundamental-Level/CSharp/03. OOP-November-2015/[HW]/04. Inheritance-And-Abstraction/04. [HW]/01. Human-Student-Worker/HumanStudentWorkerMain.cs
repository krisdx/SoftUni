using System;
using System.Collections.Generic;
using System.Linq;

public class HumanStudentWorkerMain
{
    public static void Main()
    {
        List<Student> stundets = new List<Student>
        {
           new Student("Ivan", "Ivanov", "10101010"),
           new Student("Georgi", "Georgiev", "567890001"),
           new Student("Mariq", "Mariq", "59701045"),
           new Student("Iliq", "Stoqnov", "4970234555"),
           new Student("Cezaz", "Cezarov", "000000004"),
           new Student("Evgeni", "Evgenov", "4444444444"),
           new Student("Stefan", "Stefanov", "55555"),
           new Student("Aleksandur", "Aleksandrov", "7814365"),
           new Student("Petko", "Petkov", "20582144"),
           new Student("Svetlin", "Nakov", "546935741")
        };
        var sortedStudents =
            stundets.OrderBy(student => student.FacultyNumber);

        List<Worker> workers = new List<Worker>
        {
           new Worker("Georgi", "Georgiev", 100, 8),
           new Worker("Georgi", "Georgiev", 100, 4),
           new Worker("Mariq", "Mariq", 500, 9),
           new Worker("Iliq", "Stoqnov", 500, 8),
           new Worker("Cezaz", "Cezarov", 2000, 14),
           new Worker("Evgeni", "Evgenov", 1500, 12),
           new Worker("Stefan", "Stefanov", 12, 1),
           new Worker("Aleksandur", "Aleksandrov", 50, 5),
           new Worker("Petko", "Petkov", 210, 4),
           new Worker("Svetlin", "Nakov", 900, 11)
        };
        var sortedWorkers =
            workers.OrderByDescending(worker => worker.WorkHoursPerDay);

        List<Human> humans = new List<Human>();
        humans.AddRange(sortedStudents);
        humans.AddRange(sortedWorkers);

        var sortedHumans =
            humans.OrderBy(human => human.FirstName)
            .ThenBy(human => human.LastName);
        foreach (var human in sortedHumans)
        {
            Console.WriteLine(human);
        }
    }
}