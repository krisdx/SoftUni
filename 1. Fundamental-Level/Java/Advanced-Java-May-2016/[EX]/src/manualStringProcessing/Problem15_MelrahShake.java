package manualStringProcessing;

import java.util.Scanner;

public class Problem15_MelrahShake {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        StringBuilder str = new StringBuilder(scanner.nextLine());
        StringBuilder pattern = new StringBuilder(scanner.nextLine());

        while (true) {
            if (str.length() == 0){
                System.out.println("No shake.");
                System.out.println();
                break;
            }

            int startIndex = str.indexOf(pattern.toString());
            if (startIndex == -1) {
                System.out.println("No shake.");
                System.out.println(str);
                break;
            }
            str.delete(startIndex, startIndex + pattern.length());

            int endIndex = str.lastIndexOf(pattern.toString());
            if (endIndex == -1) {
                System.out.println("No shake.");
                System.out.println(str);
                break;
            }
            str.delete(endIndex, endIndex + pattern.length());

            System.out.println("Shaked it.");

            if (pattern.length() / 2 < 1) {
                System.out.println("No shake.");
                System.out.println(str);
                break;
            }

            pattern.deleteCharAt(pattern.length() / 2);
        }
    }
}