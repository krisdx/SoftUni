package main.bg.softuni.contracts.data;

import java.util.Map;

public interface DataSorter {
    void printSortedStudents(
            Map<String, Double> courseData,
            String comparisonType,
            int numberOfStudents);
}