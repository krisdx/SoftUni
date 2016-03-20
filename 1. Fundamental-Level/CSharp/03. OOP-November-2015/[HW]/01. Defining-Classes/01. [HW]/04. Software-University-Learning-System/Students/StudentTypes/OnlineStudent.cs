public class OnlineStudent : CurrentStudent
{
    public OnlineStudent(string firstName, string lastName, int age, string studentNumber, double averageGrade, string currentCourse)
        : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
    {
    }

    public override string ToString()
    {
        return string.Format("{0} {1} [Online Student]\nAge - {2}\nStudent number - {4}\nAverage grade - {5:f2}\nCurrent course - {6}", this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AverageGrade, this.CurrentCourse);
    }
}