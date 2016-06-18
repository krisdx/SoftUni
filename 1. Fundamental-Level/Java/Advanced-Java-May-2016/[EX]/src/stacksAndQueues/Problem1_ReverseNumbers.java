package stacksAndQueues;

import java.util.Scanner;
import java.util.Stack;

public class Problem1_ReverseNumbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Stack<Integer> stack = new Stack<>();
        String[] numbers = input.nextLine().split("\\s+");
        for (int i = 0; i < numbers.length; i++) {
            int number = Integer.parseInt(numbers[i]);
            stack.add(number);
        }

        for (int i = 0; i < numbers.length; i++) {
            System.out.print(stack.pop() + " ");
        }
    }
}