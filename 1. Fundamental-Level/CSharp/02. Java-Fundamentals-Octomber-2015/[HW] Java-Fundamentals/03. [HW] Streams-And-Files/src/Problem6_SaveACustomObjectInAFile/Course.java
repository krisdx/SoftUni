package Problem6_SaveACustomObjectInAFile;

import java.io.Serializable;

public class Course implements Serializable {
    String courseName;
    int numberOfStudents;

    public Course(){
    }

    public Course(String courseName, int numberOfStudents){
        this.courseName = courseName;
        this.numberOfStudents = numberOfStudents;
    }

    @Override
    public String toString() {
        return "The " + this.courseName + " course has " + this.numberOfStudents + " students.";
    }
}