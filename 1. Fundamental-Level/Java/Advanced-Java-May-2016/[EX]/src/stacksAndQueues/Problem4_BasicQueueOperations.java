package stacksAndQueues;

import java.util.ArrayDeque;
import java.util.Queue;
import java.util.Scanner;

public class Problem4_BasicQueueOperations {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Queue<Integer> stack = new ArrayDeque<>();
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
            stack.remove();
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
                    if (num < smallestElement){
                        smallestElement = num;
                    }
                }

                System.out.println(smallestElement);
            }
        }
    }
}