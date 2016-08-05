package main.bg.softuni.contracts.models;

import java.util.*;

public interface Course extends Comparable<Course> {
    String getName();

    Map<String, Student> getStudentsByName();

    void enrollStudent(Student student);
}