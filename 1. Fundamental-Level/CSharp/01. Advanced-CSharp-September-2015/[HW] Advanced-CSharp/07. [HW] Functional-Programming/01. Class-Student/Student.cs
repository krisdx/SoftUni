// Problem 1
using System.Collections.Generic;

public class Student
{
    public Student(string firstName, string lastName, string facultyNumber, string phone, string email, IList<int> marks, int groupNumber, int age, string groupName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.FacultyNumber = facultyNumber;
        this.Phone = phone;
        this.Email = email;
        this.Marks = marks;
        this.GroupNumber = groupNumber;
        this.Age = age;
        this.GroupName = groupName;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FacultyNumber { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public IList<int> Marks { get; set; }

    public int GroupNumber { get; set; }

    public int Age { get; set; }

    public string GroupName { get; set; }
}