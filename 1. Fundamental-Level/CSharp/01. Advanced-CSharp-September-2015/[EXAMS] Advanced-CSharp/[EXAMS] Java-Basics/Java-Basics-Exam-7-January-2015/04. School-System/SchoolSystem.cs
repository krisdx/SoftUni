using System;
using System.Collections.Generic;
using System.Linq;

class SchoolSystem
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        SortedDictionary<string, SortedDictionary<string, List<decimal>>> studentGrades = new SortedDictionary<string, SortedDictionary<string, List<decimal>>>();
        for (int i = 0; i < n; i++)
        {
            string[] studentGradeDetails = Console.ReadLine().Split();
            string studentName = studentGradeDetails[0] + " " + studentGradeDetails[1];
            string subject = studentGradeDetails[2];
            decimal score = decimal.Parse(studentGradeDetails[3]);

            if (studentGrades.ContainsKey(studentName))
            {
                if (studentGrades[studentName].ContainsKey(subject))
                {
                    studentGrades[studentName][subject].Add(score);
                }
                else
                {
                    List<decimal> list = new List<decimal>() { score };
                    studentGrades[studentName].Add(subject, list);
                }
            }
            else
            {
                List<decimal> list = new List<decimal>() { score };
                SortedDictionary<string, List<decimal>> subjectAndGrade = new SortedDictionary<string, List<decimal>> {
                    {subject, list}
                };
                studentGrades.Add(studentName, subjectAndGrade);
            }
        }

        Print(studentGrades);
    }

    static void Print(SortedDictionary<string, SortedDictionary<string, List<decimal>>> studentGrades)
    {
        foreach (var student in studentGrades)
        {
            Console.Write("{0}: [", student.Key);
            int length = student.Value.Count;
            int counter = 0;
            foreach (var subjectAndGrade in student.Value)
            {
                counter++;
                if (counter != length)
                {
                    Console.Write("{0} - {1:f2}, ", subjectAndGrade.Key, subjectAndGrade.Value.Average());
                }
                else
                {
                    Console.Write("{0} - {1:f2}]", subjectAndGrade.Key, subjectAndGrade.Value.Average());
                }
            }
            Console.WriteLine();
        }
    }
}