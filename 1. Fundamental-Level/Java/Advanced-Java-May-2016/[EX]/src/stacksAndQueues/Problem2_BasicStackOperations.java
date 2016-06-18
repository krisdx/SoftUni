package stacksAndQueues;

import java.util.Scanner;
import java.util.Stack;

public class Problem2_BasicStackOperations {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Stack<Integer> stack = new Stack<>();
        String[] inputParams = input.nextLine().split("\\s");
        int n = Integer.parseInt(inputParams[0]);
        int popCount = Integer.parseInt(inputParams[1]);
        int searchNum = Integer.parseInt(inputParams[2]);

        String[] numbers = input.nextLine().split("\\s");
        for (int i = 0; i < n; i++) {
            int number = Integer.parseInt(numbers[i]);

            stack.add(number);
        }
        for (int i = 0; i < popCount; i++) {
            stack.pop();
        }

        if (stack.size() == 0) {
            System.out.println(0);
        } else {
            boolean containsNum = stack.contains(searchNum);
            if (containsNum) {
                System.out.println(containsNum);
            } else {
                int smallestElement = Integer.MAX_VALUE;
                for (Integer num : stack) {
                    if (num < smallestElement) {
                        smallestElement = num;
                    }
                }

                System.out.println(smallestElement);
            }
        }
    }
}