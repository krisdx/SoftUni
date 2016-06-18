package functionalProgramming;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.function.Function;

public class Problem5_AppliedArithmetics {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Function<Long, Long> addFunc = num -> num + 1;
        Function<Long, Long> multiplyFunc = num -> num * 2;
        Function<Long, Long> subtractFunc = num -> num - 1;

        String[] input = scanner.nextLine().trim().split("\\s+");
        List<Long> numbers = new ArrayList<>();
        for (int i = 0; i < input.length; i++) {
            numbers.add(Long.valueOf(input[i]));
        }

        while (true) {
            String line = scanner.nextLine();
            if (line.equals("end")) {
                break;
            }

            if (line.equals("add")) {
                for (int i = 0; i < numbers.size(); i++) {
                    long num = numbers.get(i);
                    long result = addFunc.apply(num);
                    numbers.set(i, result);
                }
            } else if (line.equals("multiply")) {
                for (int i = 0; i < numbers.size(); i++) {
                    long num = numbers.get(i);
                    long result = multiplyFunc.apply(num);
                    numbers.set(i, result);
                }
            } else if (line.equals("subtract")) {
                for (int i = 0; i < numbers.size(); i++) {
                    long num = numbers.get(i);
                    long result = subtractFunc.apply(num);
                    numbers.set(i, result);
                }
            } else if (line.equals("print")) {
                for (int i = 0; i < numbers.size(); i++) {
                    System.out.print(numbers.get(i) + " ");
                }
                System.out.println();
            }
        }
    }
}