package streamAPI;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem5_FilterStudentsByEmail {
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

        personInfo.stream().filter(person -> person.endsWith("@gmail.com"))
                .forEach(person -> {
                    String personArgs[] = person.split("\\s+");
                    System.out.println(personArgs[0] + " " + personArgs[1]);
                });
    }
}