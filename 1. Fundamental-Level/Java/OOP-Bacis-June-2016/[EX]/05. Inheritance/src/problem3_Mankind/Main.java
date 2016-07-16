package problem3_Mankind;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String[] studentParams = reader.readLine().split("\\s+");
        String firstName = studentParams[0];
        String lastName = studentParams[1];
        String facultyNumber = studentParams[2];

        String[] workerParams = reader.readLine().split("\\s+");
        String workerFirstName = workerParams[0];
        String workerLastName = workerParams[1];
        double weekSalary = Double.valueOf(workerParams[2]);
        double hoursPerDay = Double.valueOf(workerParams[3]);
        try {
            Student student = new Student(firstName, lastName, facultyNumber);
            Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, hoursPerDay);
            System.out.println(student);
            System.out.println(worker);
        } catch (IllegalArgumentException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
