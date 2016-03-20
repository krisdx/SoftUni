namespace InheritanceAndPolymorphism.Courses
{
    using System;
    using System.Collections.Generic;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name)
            : base(name)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the town cannot be null.");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();

            if (this.Town != null)
            {
                result += "; Town = ";
                result += this.Town;
            }

            result += " }";

            return result;
        }
    }
}