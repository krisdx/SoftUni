package stacksAndQueues;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;
import java.util.Stack;

public class Problem3_MaxElement {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Stack<Integer> stack = new Stack<>();
        Stack<Integer> maxSums = new Stack<>();

        int n = Integer.parseInt(reader.readLine());
        for (int i = 0; i < n; i++) {
            String[] inputParams = reader.readLine().split("\\s+");
            if (inputParams.length == 2) {
                int number = Integer.parseInt(inputParams[1]);
                stack.add(number);

                if (maxSums.size() == 0 || maxSums.peek() < number) {
                    maxSums.add(number);
                }
            } else {
                if (Integer.parseInt(inputParams[0]) == 2) {
                    int poppedNum = stack.pop();
                    if (maxSums.size() > 0 && poppedNum == maxSums.peek()) {
                        maxSums.pop();
                    }
                } else {
                    System.out.println(maxSums.peek());
                }
            }
        }
    }
}