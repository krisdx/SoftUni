package stacksAndQueues;

import java.util.Scanner;
import java.util.Stack;

public class Problem9_StackFibonacci {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();

        Stack<Long> stack = new Stack<>();

        stack.add(new Long(1));
        stack.add(new Long(1));
        for (int i = 2; i <= n; i++) {
            long firstNum  = stack.pop();
            long secondNum = stack.peek();
            long thirdNum = firstNum + secondNum;
            stack.add(firstNum);
            stack.add(thirdNum);
        }

        System.out.println(stack.peek());
    }
}