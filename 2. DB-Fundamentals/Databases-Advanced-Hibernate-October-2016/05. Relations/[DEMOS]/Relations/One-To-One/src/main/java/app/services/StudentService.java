package app.services;

import app.models.Student;

public interface StudentService {
    void createStudent(Student student);

    Student find(long id);
}