package streamAPI;

import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Problem11_StudentsJoinedToSpecialties { // Not finished
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<StudentSpeciality> studentSpecialities = new ArrayList<>();
        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            String[] specialityInfo = line.split("\\s+");
            String speciality = specialityInfo[0] + specialityInfo[1];
            Integer facultyNumber = Integer.valueOf(specialityInfo[2]);

            StudentSpeciality studentSpeciality = new StudentSpeciality(speciality, facultyNumber);
            studentSpecialities.add(studentSpeciality);
        }
    }
}

class StudentSpeciality {
    public String specialityName;
    public int facultyNumber;

    public StudentSpeciality(String specialityName, int facultyNumber) {
        this.specialityName = specialityName;
        this.facultyNumber = facultyNumber;
    }
}

class Student {
    public String studentName;
    public int facultyNumber;

    public Student(String studentName, int facultyNumber) {
        this.studentName = studentName;
        this.facultyNumber = facultyNumber;
    }
}