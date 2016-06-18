package streamAPI;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem8_WeakStudents {
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

            int count = 0;
            for (int i = 2; i < personArgs.length; i++) {
                int mark = Integer.valueOf(personArgs[i]);
                if (mark <= 3) {
                    count++;
                    if (count == 2) {
                        return true;
                    }
                }
            }

            return false;
        }).forEach(person -> {
            String personArgs[] = person.split("\\s+");
            System.out.println(personArgs[0] + " " + personArgs[1]);
        });
    }
}