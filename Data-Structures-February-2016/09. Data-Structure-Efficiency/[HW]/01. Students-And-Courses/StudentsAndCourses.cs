namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;

    public class StudentsAndCourses
    {
        public static void Main()
        {
            var data = new SortedDictionary<string, SortedSet<Person>>();

            string inputLine = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(inputLine))
            {
                string[] inputParams = inputLine.Trim().Split('|');
                string firstName = inputParams[0].Trim();
                string lastName = inputParams[1].Trim();
                string course = inputParams[2].Trim();

                if (!data.ContainsKey(course))
                {
                    data.Add(course, new SortedSet<Person>());
                }

                var person = new Person(firstName, lastName);
                data[course].Add(person);

                inputLine = Console.ReadLine();
            }

            foreach (var course in data)
            {
                Console.Write("{0}: ", course.Key);
                Console.WriteLine(string.Join(", ", course.Value));
            }
        }
    }
}