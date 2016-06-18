package manualStringProcessing;

import java.util.Scanner;

public class Problem14_LetterChangeNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] input = scanner.nextLine().split("\\s+");

        double sum = 0;
        for (int i = 0; i < input.length; i++) {
            double number = Double.valueOf(input[i].substring(1, input[i].length() - 1));
            char leftChar = input[i].charAt(0);
            char rightChar = input[i].charAt(input[i].length() - 1);

            if (Character.isUpperCase(leftChar)) {
                number /= (leftChar - 'A' + 1);
            } else {
                number *= (leftChar - 'a' + 1);
            }

            if (Character.isUpperCase(rightChar)) {
                number -= (rightChar - 'A' + 1);
            } else {
                number += (rightChar - 'a' + 1);
            }

            sum += number;
        }

        System.out.printf("%.2f", sum);
    }
}