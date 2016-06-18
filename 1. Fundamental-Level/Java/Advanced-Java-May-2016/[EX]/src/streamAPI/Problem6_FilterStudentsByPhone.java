package streamAPI;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem6_FilterStudentsByPhone {
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

            String phone = personArgs[2];
            if (phone.startsWith("02") || phone.startsWith("+3592")) {
                return true;
            }

            return false;
        }).forEach(person -> {
            String personArgs[] = person.split("\\s+");
            System.out.println(personArgs[0] + " " + personArgs[1]);
        });
    }
}