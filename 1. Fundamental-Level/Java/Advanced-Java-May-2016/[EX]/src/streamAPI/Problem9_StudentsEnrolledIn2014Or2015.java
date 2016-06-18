package streamAPI;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem9_StudentsEnrolledIn2014Or2015 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<String> personInfo = new ArrayList<>();
        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            personInfo.add(line);
        }

        personInfo.stream().filter(person -> {
            String personArgs[] = person.split("\\s+");
            String facultyNumber = personArgs[0];
            if (facultyNumber.endsWith("14") ||
                    facultyNumber.endsWith("15")){
                return true;
            }

            return false;
        }).forEach(person -> {
            String personArgs[] = person.split("\\s+");
            for (int i = 1; i < personArgs.length; i++) {
                System.out.print(personArgs[i] + " ");
            }
            System.out.println();
        });
    }
}
