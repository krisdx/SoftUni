public class StudentSpecialty
{
    public StudentSpecialty(string specialtyName, string facultyNumber)
    {
        this.SpecialtyName = specialtyName;
        this.FacultyNumber = facultyNumber;
    }

    public string SpecialtyName { get; set; }
    public string FacultyNumber { get; set; }
}