package setsAndMaps;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Problem6_MinerMask {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Map<String, Long> resources = new LinkedHashMap<>();
        while (true) {
            String resource = input.nextLine();
            if (resource.equals("stop")) {
                break;
            }

            long amount = Integer.parseInt(input.nextLine());
            if (!resources.containsKey(resource)) {
                resources.put(resource, amount);
            } else {
                long currentAmount = resources.get(resource);
                resources.put(resource, currentAmount + amount);
            }
        }

        for (Map.Entry<String, Long> resource : resources.entrySet()) {
            System.out.printf("%s -> %s\n", resource.getKey(), resource.getValue());
        }
    }
}