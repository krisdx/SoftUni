namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime birthDate =
                DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            DateTime otherPersonsBirthDate =
                DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));

            bool isOlderThanOtherPerson = birthDate > otherPersonsBirthDate;
            return isOlderThanOtherPerson;
        }
    }
}