package Algorithms_Live_Exam_Preparation;

import java.util.Scanner;

public class Parenthesis {

    private static final char OPEN_PARENTHESIS = '(';
    private static final char CLOSED_PARENTHESIS = ')';

    private static StringBuilder output = new StringBuilder();

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = scanner.nextInt();

        char[] parenthesis = new char[n * 2];
        for (int i = 0; i < n; i++) {
            parenthesis[i] = OPEN_PARENTHESIS;
        }
        for (int i = n; i < parenthesis.length; i++) {
            parenthesis[i] = CLOSED_PARENTHESIS;
        }

        permuteRep(parenthesis, 0, parenthesis.length - 1);
        System.out.println(output.toString().trim());
    }

    private static void permuteRep(char[] parentheses, int start, int end) {
        if (isValid(parentheses)) {
            append(parentheses);
        }

        for (int left = end; left >= start; left--) {
            for (int right = left + 1; right <= end; right++) {
                if (parentheses[left] != parentheses[right]) {
                    swap(parentheses, left, right);
                    permuteRep(parentheses, left + 1, end);
                }
            }

            // Undo all modifications done by the
            // previous recursive calls and swaps
            char firstElement = parentheses[left];
            System.arraycopy(parentheses, left + 1, parentheses, left, end - left);
            parentheses[end] = firstElement;
        }
    }

    private static void append(char[] parentheses) {
        for (char parenthesis : parentheses) {
            output.append(parenthesis);
        }

        output.append(System.lineSeparator());
    }

    private static boolean isValid(char[] parentheses) {
        int balance = 0;
        for (char parenthesis : parentheses) {
            if (parenthesis == OPEN_PARENTHESIS) {
                balance++;
            } else {
                balance--;
            }

            if (balance < 0) {
                return false;
            }
        }

        return true;
    }

    private static void swap(char[] arr, int firstIndex, int secondIndex) {
        char swapValue = arr[firstIndex];
        arr[firstIndex] = arr[secondIndex];
        arr[secondIndex] = swapValue;
    }
}