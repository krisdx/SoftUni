package problem4_Telephony;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Smartphone smartphone = new Smartphone();

        String[] numbers = scanner.nextLine().split("\\s+");
        for (String number : numbers) {
            if (!containsOnlyDigits(number)) {
                System.out.println("Invalid number!");
            }

            smartphone.call(number);
        }

        String[] sites = scanner.nextLine().split("\\s+");
        for (String site : sites) {
            if (containsDigit(site)) {
                System.out.println("Invalid URL!");
            }

            smartphone.browse(site);
        }
    }

    private static boolean containsOnlyDigits(String number) {
        for (int i = 0; i < number.length(); i++) {
            try {
                Character character = number.charAt(i);
                int digit = Integer.parseInt(character.toString());
            } catch (NumberFormatException ex) {
                return false;
            }
        }

        return true;
    }

    private static boolean containsDigit(String site) {
        for (int i = 0; i < site.length(); i++) {
            try {
                Character character = site.charAt(i);
                int digit = Integer.parseInt(character.toString());
                return false;
            } catch (NumberFormatException ex) {
                continue;
            }
        }

        return true;
    }
}