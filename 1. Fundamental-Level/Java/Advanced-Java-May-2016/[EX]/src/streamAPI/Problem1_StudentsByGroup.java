package streamAPI;

import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Problem1_StudentsByGroup {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Map<String, Integer> map = new LinkedHashMap<>();

        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            String[] peronArgs = line.split("[\\s]+");
            String name = peronArgs[0]  + " " + peronArgs[1];
            Integer group  = Integer.valueOf(peronArgs[2]);

            map.put(name, group);
        }

        map.entrySet().stream().filter(entry -> entry.getValue() == 2)
                .sorted((name1, name2) -> name1.getKey().compareTo(name2.getKey()))
                .forEach(name -> System.out.println(name.getKey()));

    }
}