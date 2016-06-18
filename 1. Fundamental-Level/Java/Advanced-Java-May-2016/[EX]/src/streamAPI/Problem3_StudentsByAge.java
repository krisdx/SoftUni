package streamAPI;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Problem3_StudentsByAge {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Map<String, Integer> map = new LinkedHashMap<>();

        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            String[] peronArgs = line.split("[\\s]+");
            String name = peronArgs[0] + " " + peronArgs[1];
            Integer group = Integer.valueOf(peronArgs[2]);

            map.put(name, group);
        }

        map.entrySet().stream()
                .filter(entry -> entry.getValue() >= 18 && entry.getValue() <= 24)
                .forEach(name -> System.out.println(name.getKey() + " " + name.getValue()));
    }
}