package Repository;

import IO.OutputWriter;
import StaticData.ExceptionMessages;

import java.util.List;
import java.util.Map;
import java.util.function.Predicate;

public class RepositoryFilters {
    public static void printFilteredStudents(
            Map<String, List<Integer>> courseData,
            String filterType,
            Integer numberOfStudents) {
        Predicate<Double> filter = createFilter(filterType);
        if (filter == null) {
            OutputWriter.writeMessageOnNewLine(ExceptionMessages.INVALID_FILTER);
            return;
        }

        int studentsCount = 0;
        for (String student : courseData.keySet()) {
            if (studentsCount == numberOfStudents) {
                break;
            }

            List<Integer> studentMarks = courseData.get(student);
            Double averageMark = studentMarks
                    .stream()
                    .mapToInt(Integer::valueOf)
                    .average()
                    .getAsDouble();
            Double percentageOfFulfilment = averageMark / 100;
            Double mark = (percentageOfFulfilment * 4) + 2;
            if (filter.test(mark)) {
                OutputWriter.printStudent(student, studentMarks);
                studentsCount++;
            }
        }
    }

    private static Predicate<Double> createFilter(String filterType) {
        switch (filterType) {
            case "excellent":
                return mark -> mark >= 5.0;
            case "average":
                return mark -> mark >= 3.5 && mark < 5.0;
            case "poor":
                return mark -> mark < 3.5;
            default:
                return null;
        }
    }

    // Non functional wat of getting the average mark
    /*private static Double getStudentAverageGrade(List<Integer> grades) {
        Double totalScore = 0.0;
        for (Integer grade : grades) {
            totalScore += grade;
        }

        Double percentage = totalScore / (grades.size() * 100.0);
        return (percentage * 4) + 2;
    }*/
}