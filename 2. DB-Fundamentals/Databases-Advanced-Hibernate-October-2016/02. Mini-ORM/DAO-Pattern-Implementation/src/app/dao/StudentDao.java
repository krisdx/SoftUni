package app.dao;

import app.models.Student;

import java.sql.SQLException;
import java.util.List;

public interface StudentDao extends AutoCloseable {

    List<Student> getAllStudents() throws SQLException;

    void insertStudent(Student student) throws SQLException;

    void updateStudent(Student student) throws SQLException;

    void deleteStudent(Student student) throws SQLException;
}