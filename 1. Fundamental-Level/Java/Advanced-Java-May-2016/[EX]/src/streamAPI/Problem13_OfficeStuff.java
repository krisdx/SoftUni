package streamAPI;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Problem13_OfficeStuff {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.valueOf(scanner.nextLine());

        Map<String, Map<String, Integer>> officeStuff = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String line = scanner.nextLine();
            String[] officeStuffDetails = line.substring(1, line.length() - 1).trim().split("[\\s\\-]+");

            String companyName = officeStuffDetails[0].trim();
            int amount = Integer.valueOf(officeStuffDetails[1].trim());
            String product = officeStuffDetails[2].trim();

            if (officeStuff.containsKey(companyName)) {
                if (officeStuff.get(companyName).containsKey(product)) {
                    int oldAmount = officeStuff.get(companyName).get(product);
                    int newAmount = oldAmount + amount;
                    officeStuff.get(companyName).put(product, newAmount);
                } else {
                    officeStuff.get(companyName).put(product, amount);
                }
            } else {
                Map<String, Integer> productAndAmount = new LinkedHashMap<String, Integer>();
                productAndAmount.put(product, amount);

                officeStuff.put(companyName, productAndAmount);
            }
        }

        print(officeStuff);
    }

    private static void print(Map<String, Map<String, Integer>> officeStuff) {
        for (Map.Entry<String, Map<String, Integer>> entry : officeStuff.entrySet()) {
            System.out.printf("%s: ", entry.getKey());
            int length = entry.getValue().size();
            int counter = 1;
            for (Map.Entry<String, Integer> stringIntegerEntry : entry.getValue().entrySet()) {
                if (counter != length) {
                    System.out.printf("%s-%s, ", stringIntegerEntry.getKey(), stringIntegerEntry.getValue());
                } else {
                    System.out.printf("%s-%s", stringIntegerEntry.getKey(), stringIntegerEntry.getValue());
                }

                counter++;
            }

            System.out.println();
        }
    }
}