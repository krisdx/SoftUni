package manualStringProcessing;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class Problem7_SumBigNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String firstNum = scanner.next();
        String secondNum = scanner.next();

        Deque<String> result = new ArrayDeque<>();

        int carry = 0;
        int lastAddedCarry = 0;
        int firstNumDigitIndex = firstNum.length() - 1;
        int secondNumDigitIndex = secondNum.length() - 1;
        int maxLength = Math.max(firstNum.length(), secondNum.length());
        for (int i = 0; i < maxLength; i++) {
            int firstNumDigit = getDigit(firstNum, firstNumDigitIndex);
            firstNumDigitIndex--;
            int secondNumDigit = getDigit(secondNum, secondNumDigitIndex);
            secondNumDigitIndex--;

            Integer sum = firstNumDigit + secondNumDigit + carry;
            if (carry != 0) {
                carry -= lastAddedCarry;
            }

            if (sum < 10) {
                result.addFirst(sum.toString());
                if (carry != 0) {
                    carry -= lastAddedCarry;
                }
            } else {
                if (i + 1 == maxLength) {
                    result.addFirst(sum.toString());
                } else {
                    Integer digitToAppend = sum % 10;
                    result.addFirst(digitToAppend.toString());
                    carry += Character.getNumericValue(sum.toString().charAt(0));
                    lastAddedCarry = Character.getNumericValue(sum.toString().charAt(0));
                }
            }
        }

        result.forEach(System.out::print);
    }

    private static int getDigit(String number, int index) {
        if (index < 0) {
            return 0;
        }

        return Character.getNumericValue(number.charAt(index));
    }
}