package streamAPI;

import java.util.*;

public class Problem2_StudentsByFirstAndLastName {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<String> names = new ArrayList<>();
        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            String[] peronArgs = line.split("[\\s]+");
            names.add(peronArgs[0] + " " + peronArgs[1]);
        }

        names.stream()
                .filter(entry -> {
                    String[] peronArgs = entry.split("[\\s]+");
                    String firstName = peronArgs[0];
                    String secondName = peronArgs[1];
                    int resultIndex = firstName.compareTo(secondName);
                    if (resultIndex >= 1) {
                        return false;
                    }

                    return true;
                }).forEach(System.out::println);
    }
}