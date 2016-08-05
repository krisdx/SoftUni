package main.bg.softuni.io.commands;

import main.bg.softuni.annotations.Alias;
import main.bg.softuni.annotations.Inject;
import main.bg.softuni.contracts.Executable;
import main.bg.softuni.contracts.database.Database;
import main.bg.softuni.contracts.models.Course;
import main.bg.softuni.contracts.models.Student;
import main.bg.softuni.dataStructures.SimpleSortedList;
import main.bg.softuni.exceptions.InvalidInputException;
import main.bg.softuni.io.OutputWriter;

import java.util.Comparator;

@Alias("display")
public class DisplayCommand extends Command implements Executable {

    @Inject
    private Database repository;

    public DisplayCommand(String input, String[] data) {
        super(input, data);
    }

    @Override
    public void execute() throws Exception {
        String[] data = this.getData();
        if (data.length != 3) {
            throw new InvalidInputException(this.getInput());
        }

        String entityToDisplay = data[1];
        String sortType = data[2];
        if (entityToDisplay.equalsIgnoreCase("students")) {
            Comparator<Student> studentComparator =
                    this.createStudentComparator(sortType);
            SimpleSortedList<Student> list =
                    this.repository.getAllStudentsSorted(studentComparator);
            OutputWriter.writeMessageOnNewLine(list.joinWith(System.lineSeparator()));
        } else if (entityToDisplay.equalsIgnoreCase("courses")) {
            Comparator<Course> courseComparator =
                    this.createCourseComparator(sortType);
            SimpleSortedList<Course> list =
                    this.repository.getAllCoursesSorted(courseComparator);
            OutputWriter.writeMessageOnNewLine(list.joinWith(System.lineSeparator()));
        } else {
            throw new InvalidInputException(this.getInput());
        }
    }

    private Comparator<Course> createCourseComparator(String sortType) {
        if (sortType.equalsIgnoreCase("ascending")) {
            return (course1, course2) -> course1.compareTo(course2);
        } else if (sortType.equalsIgnoreCase("descending")) {
            return (course1, course2) -> course2.compareTo(course1);
        } else {
            throw new InvalidInputException(this.getInput());
        }
    }

    private Comparator<Student> createStudentComparator(String sortType) {
        if (sortType.equalsIgnoreCase("ascending")) {
            return (student1, student2) -> student1.compareTo(student2);
        } else if (sortType.equalsIgnoreCase("descending")) {
            return (student1, student2) -> student2.compareTo(student1);
        } else {
            throw new InvalidInputException(this.getInput());
        }
    }
}