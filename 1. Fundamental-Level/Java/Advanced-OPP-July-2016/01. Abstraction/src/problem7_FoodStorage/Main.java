package problem7_FoodStorage;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Map<String, Buyer> buyers = new HashMap<>();

        int n = Integer.valueOf(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            String[] lineArgs = scanner.nextLine().split("\\s+");
            Buyer buyer = null;
            if (lineArgs.length == 4) {
                String name = lineArgs[0];
                int age = Integer.valueOf(lineArgs[1]);
                String id = lineArgs[2];
                String birthdate = lineArgs[3];

                buyer = new Citizen(name, age, id, birthdate);
                buyers.put(name, buyer);
            } else if (lineArgs.length == 3) {
                String name = lineArgs[0];
                int age = Integer.valueOf(lineArgs[1]);
                String group = lineArgs[2];

                buyer = new Rebel(name, age, group);
                buyers.put(name, buyer);
            }
        }

        int totalAmount = 0;
        while (true) {
            String name = scanner.nextLine();
            if (name.equals("End")) {
                break;
            }

            if (!buyers.containsKey(name)) {
                continue;
            }

            totalAmount += buyers.get(name).buyFood();
        }

        System.out.println(totalAmount);
    }
}
