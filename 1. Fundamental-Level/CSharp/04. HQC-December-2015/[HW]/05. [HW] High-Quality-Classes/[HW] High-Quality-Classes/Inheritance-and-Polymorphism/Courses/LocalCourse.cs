namespace InheritanceAndPolymorphism.Courses
{
    using System;
    using System.Collections.Generic;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : base(name)
        {
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the lab cannot be null.");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();

            if (this.Lab != null)
            {
                result += "; Lab = ";
                result += this.Lab;
            }

            result += " }";

            return result;
        }
    }
}