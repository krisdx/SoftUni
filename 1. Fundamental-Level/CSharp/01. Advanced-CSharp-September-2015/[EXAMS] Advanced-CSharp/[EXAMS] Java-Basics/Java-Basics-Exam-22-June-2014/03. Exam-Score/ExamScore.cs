using System;
using System.Collections.Generic;
using System.Linq;


class ExamScore
{
    static void Main()
    {
        for (int i = 0; i < 3; i++)
        {
            string unimportantThings = Console.ReadLine();
        }

        SortedDictionary<int, SortedDictionary<string, double>> examScores = new SortedDictionary<int, SortedDictionary<string, double>>();

        string studentAndScore = Console.ReadLine();
        while (!studentAndScore.Contains('-'))
        {
            string[] examDetalis = studentAndScore.Split(new char[] { ' ', '\t', '|' }, StringSplitOptions.RemoveEmptyEntries);
            string studentName = examDetalis[0] + " " + examDetalis[1];
            int score = int.Parse(examDetalis[2]);
            double grade = double.Parse(examDetalis[3]);

            if (examScores.ContainsKey(score))
            {
                if (examScores[score].ContainsKey(studentName))
                {
                    examScores[score][studentName] += grade;
                }
                else
                {
                    examScores[score].Add(studentName, grade);
                }
            }
            else
            {
                SortedDictionary<string, double> nameAndGrade = new SortedDictionary<string, double>
                {
                    { studentName, grade }
                };

                examScores.Add(score, nameAndGrade);
            }

            studentAndScore = Console.ReadLine();
        }

        foreach (var score in examScores)
        {
            Console.Write("{0} -> [", score.Key);
            int length = score.Value.Count;
            int count = 0;
            double sumGrade = 0;
            foreach (var student in score.Value)
            {
                count++;
                if (count == length)
                {
                    Console.Write("{0}", student.Key);
                }
                else
                {
                    Console.Write("{0}, ", student.Key);
                }
                sumGrade += student.Value;
            }
            Console.WriteLine("]; avg={0:F2}", sumGrade / length);
        }
    }
}