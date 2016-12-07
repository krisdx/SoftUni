package app.dao;

import app.connection.DatabaseConnection;
import app.models.Student;
import app.slqQuery.SQLQueries;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class StudentDaoImpl implements StudentDao, AutoCloseable {

    private Connection connection;
    private PreparedStatement preparedStatement;
    private ResultSet resultSet;

    @Override
    public List<Student> getAllStudents() throws SQLException {
        this.getConnection();
        this.preparedStatement =
                this.connection.prepareStatement(SQLQueries.SELECT_ALL_STUDENTS);
        this.resultSet = preparedStatement.executeQuery();

        List<Student> students = new ArrayList<>();
        while (this.resultSet.next()) {
            int studentId = this.resultSet.getInt("id");
            String studentName = this.resultSet.getString("name");
            Student student = new Student(studentId, studentName);
            students.add(student);
        }

        return students;
    }

    @Override
    public void insertStudent(Student student) throws SQLException {
        this.getConnection();
        this.preparedStatement =
                this.connection.prepareStatement(SQLQueries.INSERT_STUDENT);
        this.preparedStatement.setInt(1, student.getId());
        this.preparedStatement.setString(2, student.getName());

        this.preparedStatement.execute();
    }

    @Override
    public void updateStudent(Student student) throws SQLException {
        this.getConnection();
        this.preparedStatement =
                this.connection.prepareStatement(SQLQueries.UPDATE_STUDENT);
        this.preparedStatement.setString(1, student.getName());
        this.preparedStatement.setInt(2, student.getId());

        this.preparedStatement.execute();
    }

    @Override
    public void deleteStudent(Student student) throws SQLException {
        this.getConnection();
        this.preparedStatement =
                this.connection.prepareStatement(SQLQueries.DELETE_STUDENT);
        this.preparedStatement.setInt(1, student.getId());

        this.preparedStatement.execute();
    }

    @Override
    public void close() throws Exception {
        if (this.resultSet != null) {
            this.resultSet.close();
        }

        if (this.preparedStatement != null) {
            this.preparedStatement.close();
        }

        if (this.connection != null) {
            this.connection.close();
        }
    }

    private void getConnection() throws SQLException {
        this.connection = DatabaseConnection.getConnection();
    }
}
