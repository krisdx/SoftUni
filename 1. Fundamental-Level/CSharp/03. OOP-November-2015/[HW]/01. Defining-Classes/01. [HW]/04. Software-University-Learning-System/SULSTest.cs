using System;
using System.Collections.Generic;
using System.Linq;

public class SULSTest
{
    public static void Main()
    {
        Person person = new Person("Person", "Person", 100);

        // Students
        Student student = new Student("Gosho", "Goshev", 25, "89948949", 4.50);
        CurrentStudent currentStudent = new CurrentStudent("Mariq", "Ivanova", 18, "8251049", 5.00, "Java Basics");
        OnlineStudent onlineStudent = new OnlineStudent("Hristo", "Georviev", 30, "109890333", 4.00, "Web Development Basics");
        OnsiteStudent onsiteStudent = new OnsiteStudent("Iliq", "Iliev", 25, "804008222", 5.50, "Teamwork and Personal Skills", 15);
        
        GraduateStudent graduateStudent = new GraduateStudent("Ivan", "Todorov", 40, "401513", 6.00);

        DropoutStudent dropoutStudent = new DropoutStudent("Goshko", "Goshkov", 33, "584981894", 3.50, "Don't have enough time.");
        dropoutStudent.Reapply();
        
        // Trainers
        Trainer trainer = new Trainer("Filip", "Kolev", 28);

        JuniorTrainer juniorTrainer = new JuniorTrainer("Nasko", "Rusenov", 20);
        juniorTrainer.CreateCourse("OOP");

        SeniorTrainer seniorTrainer = new SeniorTrainer("Svetlin", "Nakov", 33);
        seniorTrainer.DeleteCourse("JavaScrips OOP");

        List<Person> people = new List<Person>
        {
            person,
            student,
            currentStudent,
            onlineStudent,
            onsiteStudent,
            graduateStudent,
            dropoutStudent,
            trainer,
            juniorTrainer,
            seniorTrainer
        };

        Console.WriteLine();

        var currentStudents =
            people.Where(x => x is CurrentStudent)
            .OrderBy(y => ((Student)y).AverageGrade);
        Console.WriteLine("Current students sorted by average grade: ");
        foreach (var currStudent in currentStudents)
        {
            Console.WriteLine();
            Console.WriteLine(currentStudent);
        }
    }
}