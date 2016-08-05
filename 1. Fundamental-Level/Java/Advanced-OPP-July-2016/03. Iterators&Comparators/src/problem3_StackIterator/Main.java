package problem3_StackIterator;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.NoSuchElementException;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

                CustomStack<Integer> stack = new CustomStack<>();
        while (true) {
            String line = reader.readLine();
            if (line.equals("END")) {
                break;
            }

            if (line.contains("Push")) {
                int spaceIndex = line.indexOf(" ");
                int[] numbers = Arrays.stream(
                        line.substring(spaceIndex + 1)
                                .trim()
                                .split(", "))
                        .mapToInt(Integer::valueOf)
                        .toArray();
                for (int number : numbers) {
                    stack.push(number);
                }
            } else if (line.equals("Pop")) {
                try {
                    stack.pop();
                } catch (NoSuchElementException ex) {
                    System.out.println(ex.getMessage());
                }
            }
        }

        for (Integer number : stack) {
            System.out.println(number);
        }

        for (Integer number : stack) {
            System.out.println(number);
        }
    }
}
