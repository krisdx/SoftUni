package manualStringProcessing;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class Problem8_MultiplyBIgNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String multiplicand = scanner.next();
        int multiplier = scanner.nextInt();

        if (multiplicand.equals("0") || multiplier == 0) {
            System.out.println(0);
            return;
        }

        Deque<String> result = new ArrayDeque<>();

        int carry = 0;
        int lastAddedCarry = 0;
        for (int i = multiplicand.length() - 1; i >= 0; i--) {
            int digit = Character.getNumericValue(multiplicand.charAt(i));
            Integer multiplyResult = (digit * multiplier) + carry;
            if (carry != 0) {
                carry -= lastAddedCarry;
            }

            if (multiplyResult < 10) {
                result.addFirst(multiplyResult.toString());
                if (carry != 0) {
                    carry -= lastAddedCarry;
                }
            } else {
                if (i - 1 < 0) {
                    result.addFirst(multiplyResult.toString());
                } else {
                    Integer digitToAppend = multiplyResult % 10;
                    result.addFirst(digitToAppend.toString());
                    carry += Character.getNumericValue(multiplyResult.toString().charAt(0));
                    lastAddedCarry = Character.getNumericValue(multiplyResult.toString().charAt(0));
                }
            }
        }

        while (result.size() > 0 && result.peekFirst().equals("0")) {
            result.removeFirst();
        }

        result.forEach(System.out::print);
    }
}