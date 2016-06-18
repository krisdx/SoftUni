package streamAPI;

import java.util.*;

public class Problem4_SortStudents {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<String> names = new ArrayList<>();

        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            names.add(line);
        }

        names.stream()
                .sorted((firstName, secondName) -> {
                    String[] firstNameArgs = firstName.split("\\s+");
                    String firstName1 = firstNameArgs[0];
                    String lastName1 = firstNameArgs[1];

                    String[] secondNameArgs = secondName.split("\\s+");
                    String firstName2 = secondNameArgs[0];
                    String lastName2 = secondNameArgs[1];

                    if (lastName1.equals(lastName2)) {
                        return firstName2.compareTo(firstName1);
                    }

                    return lastName1.compareTo(lastName2);
                }).forEach(System.out::println);
    }
}
