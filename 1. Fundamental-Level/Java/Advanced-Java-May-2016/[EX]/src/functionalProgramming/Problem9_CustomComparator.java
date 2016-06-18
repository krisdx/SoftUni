package functionalProgramming;

import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

public class Problem9_CustomComparator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] input = scanner.nextLine().split("\\s+");
        Integer[] numbers = new Integer[input.length];
        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = Integer.valueOf(input[i]);
        }

        Comparator<Integer> customComparator = (firstNum, secondNum) -> {
            // Math.abs() is for negative numbers
            if (Math.abs(firstNum) % 2 == 0 &&
                    Math.abs(secondNum) % 2 == 1) {
                // comparing odd with even number
                // return -1, because even numbers have to be
                // before odd numbers
                return -1;
            } else if (Math.abs(firstNum) % 2 == 1 &&
                    Math.abs(secondNum)% 2 == 0) {
                // comparing even with odd number
                // return 1, because odd numbers have to be
                // after even numbers
                return 1;
            } else {
                // even with even numbers or odd with odd numbers
                // just returning the bigger one
                return firstNum.compareTo(secondNum);
            }
        };

        Arrays.sort(numbers, customComparator);
        for (Integer number : numbers) {
            System.out.print(number + " ");
        }
    }
}