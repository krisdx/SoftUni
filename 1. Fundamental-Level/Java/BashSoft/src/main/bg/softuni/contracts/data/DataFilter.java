package main.bg.softuni.contracts.data;

import java.util.Map;

public interface DataFilter {
    void printFilteredStudents(
            Map<String, Double> studentsWithMarks,
            String filterType,
            Integer numberOfStudents);
}