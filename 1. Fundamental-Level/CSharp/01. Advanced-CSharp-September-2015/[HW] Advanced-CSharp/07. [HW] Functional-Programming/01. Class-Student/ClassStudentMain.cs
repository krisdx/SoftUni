using System;
using System.Collections.Generic;
using System.Linq;

public class ClassStudent
{
    static void Main()
    {
        // Problem 1
        List<Student> studentsList = new List<Student>
        {
            new Student("Pesho", "Todorov","800014", "029574129", "pesho@gmail.com", new List<int>{ 2, 3, 4 }, 2, 22,"CSharp"),

            new Student("Maria", "Marieva", "400114", "+1258570129", "maria@abv.bg", new List<int>{ 6, 6, 6, 6 }, 1, 18, "CSharp"),

            new Student("Stamat", "Asenov", "700015", "+359 2807415", "stamat@gmail.com", new List<int>{ 2, 2, 4}, 2, 30, "JavaScript"),

            new Student("Nashmat", "Pavlov", "300015", "+35968574128", "nashmat@abv.bg", new List<int>{ 4, 3, 4 }, 4, 27, "JavaScript")
        };

        //// Problem 2
        //StudentsFromGroupTwo(studentsList);

        //// Problem 3
        //SortStudentsByFirstAndLastName(studentsList);

        //// Problem 4 
        //SortStudentsByAge(studentsList);

        //// Problem 5
        //SortStudentsByFirstAndLastName2(studentsList);

        //// Problem 6 
        //FilterStudentsByEmail(studentsList);

        //// Problem 7
        //FilterStudentsByPhone(studentsList);

        //// Problem 8
        //StudentsWithExcellentGrades(studentsList);

        //// Problem 9 
        //StudentsWithWeakGrades(studentsList);

        //// Problem 10
        //StudentsEnrolledIn2014(studentsList);

        ///// Problem 11
        //StudentGroups(studentsList);

        //// Problem 12 
        //List<StudentSpecialty> studentSpecialties = new List<StudentSpecialty>
        //{
        //    new StudentSpecialty("Web Developer", "700015"),
        //    new StudentSpecialty("JavaScript Developer", "500114"),
        //    new StudentSpecialty("Back-End Developer", "130114"),
        //    new StudentSpecialty("PHP Developer", "300015"),
        //    new StudentSpecialty("PHP Developer", "800014"),
        //    new StudentSpecialty("JavaScript Developer", "400114"),
        //};

        //JoinSpecialties(studentsList, studentSpecialties);
    }

    public static void StudentsFromGroupTwo(List<Student> studentsList)
    {
        var studentsFromGroupTwo =
            from student in studentsList
            where student.GroupNumber == 2
            select student;

        Console.WriteLine("Students with group number 2:");
        foreach (var student in studentsFromGroupTwo)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }

    public static void SortStudentsByFirstAndLastName(List<Student> studentsList)
    {
        var studentsByFirstAndLastName =
            from student in studentsList
            where student.FirstName[0] < student.LastName[0]
            select student;

        Console.WriteLine("Students whose first name is before their last name alphabetically:");
        foreach (var student in studentsByFirstAndLastName)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }

    public static void SortStudentsByAge(List<Student> studentsList)
    {
        var studentsByAge =
            from student in studentsList
            where student.Age >= 18 && student.Age <= 24
            select new { student.FirstName, student.LastName };

        Console.WriteLine("Students with age between 18 and 24:");
        foreach (var student in studentsByAge)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }

    public static void SortStudentsByFirstAndLastName2(List<Student> studentsList)
    {
        //var sortedStudents = studentsList.OrderByDescending(name => name.FirstName).ThenByDescending(name => name.LastName);

        var sortedStudents =
            from student in studentsList
            orderby student.FirstName descending,
            student.LastName descending
            select student;

        Console.WriteLine("Students with sorted names (by descending order):");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }

    public static void FilterStudentsByEmail(List<Student> studentsList)
    {
        var studentsByEmail =
            from student in studentsList
            where student.Email.Contains("abv.bg")
            select student;

        Console.WriteLine("Students with email @abv.bg:");
        foreach (var student in studentsByEmail)
        {
            Console.WriteLine("{0} {1} - {2}", student.FirstName, student.LastName, student.Email);
        }
    }

    public static void FilterStudentsByPhone(List<Student> studentsList)
    {
        var studentsByPhone =
            from student in studentsList
            where student.Phone.Contains("02") ||
                student.Phone.Contains("+359") ||
                student.Phone.Contains("+359 2")
            select student;

        Console.WriteLine("Students with phone starting with (02 / +3592 / +359 2):");
        foreach (var student in studentsByPhone)
        {
            Console.WriteLine("{0} {1} - {2}", student.FirstName, student.LastName, student.Phone);
        }
    }

    public static void StudentsWithExcellentGrades(List<Student> studentsList)
    {
        var studentsWithExcellentGrades =
            from student in studentsList
            where student.Marks.Contains(6)
            select new { student.FirstName, student.Marks };

        Console.WriteLine("Students with at least one exellent grade:");
        foreach (var student in studentsWithExcellentGrades)
        {
            Console.WriteLine("{0} -  {{ {1} }}", student.FirstName, string.Join(", ", student.Marks));
        }
    }

    public static void StudentsWithWeakGrades(List<Student> studentsList)
    {
        var studentsWithWeakGrades =
            from student in studentsList
            .Where(student => (student.Marks.Count(grade => grade == 2)) == 2)
            select student;

        Console.WriteLine("Students with weak grades:");
        foreach (var student in studentsWithWeakGrades)
        {
            Console.WriteLine("{0} -  {{ {1} }}", student.FirstName, string.Join(", ", student.Marks));
        }
    }

    public static void StudentsEnrolledIn2014(List<Student> studentsList)
    {
        var studentsEnrolledIn2014 =
            from student in studentsList
            where student.FacultyNumber[5 - 1] == '1' && student.FacultyNumber[6 - 1] == '4'
            select new
            {
                student.FirstName,
                student.Marks
            };

        Console.WriteLine("Marks of the students that are enrolled in 2014:");
        foreach (var student in studentsEnrolledIn2014)
        {
            Console.WriteLine("{0} -  {{ {1} }}", student.FirstName, string.Join(", ", student.Marks));
        }
    }

    public static void StudentGroups(List<Student> studentsList)
    {
        var studentGroups =
            from student in studentsList
            group student by student.GroupName into G
            select G;

        foreach (var group in studentGroups)
        {
            Console.WriteLine("Group name: \"{0}\". Members: ", group.Key);
            int counter = 1;
            foreach (var student in group)
            {
                Console.WriteLine("{0}. {1} {2}", counter, student.FirstName, student.LastName);
                counter++;
            }
            Console.WriteLine();
        }
    }

    public static void JoinSpecialties(List<Student> studentsList, List<StudentSpecialty> studentSpecialties)
    {
        var joinSpecialties =
            from student in studentsList
            join specialty in studentSpecialties
            on student.FacultyNumber equals specialty.FacultyNumber
            select new
            {
                student.FirstName,
                student.LastName,
                specialty.FacultyNumber,
                specialty.SpecialtyName
            };

        Console.WriteLine("{0}\n", new string('-', 50));
        Console.WriteLine("{0}Name{0}FacultyNumber{0}Specialty", new string('-', 4));
        foreach (var studentAndSpecialty in joinSpecialties)
        {
            Console.WriteLine("{0} {1} - {2} - {3}", studentAndSpecialty.FirstName, studentAndSpecialty.LastName, studentAndSpecialty.FacultyNumber, studentAndSpecialty.SpecialtyName);
        }
        Console.WriteLine("\n{0}", new string('-', 50));
    }
}