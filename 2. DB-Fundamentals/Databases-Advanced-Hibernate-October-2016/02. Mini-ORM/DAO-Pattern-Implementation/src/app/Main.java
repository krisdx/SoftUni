package app;

import app.dao.StudentDao;
import app.dao.StudentDaoImpl;
import app.models.Student;

import java.sql.SQLException;

public class Main {

    public static void main(String[] args) {
        try (StudentDao studentDao = new StudentDaoImpl()) {

            // Inserting student
            studentDao.insertStudent(new Student("Pesho"));

            // Get, Update and Delete student
            int randomId = 4;
            studentDao.getAllStudents().forEach(s -> {
                if (s.getId() == randomId) {
                    Student student = new Student(s.getId(), "Asen");
                    try {
                        studentDao.updateStudent(student);
                        studentDao.deleteStudent(student);
                    } catch (SQLException slqEx) {
                        slqEx.printStackTrace();
                    }
                }
            });
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}