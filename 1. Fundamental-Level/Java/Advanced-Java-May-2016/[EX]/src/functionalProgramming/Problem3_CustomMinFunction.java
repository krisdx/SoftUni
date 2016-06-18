package functionalProgramming;

import java.util.Scanner;
import java.util.function.Function;

public class Problem3_CustomMinFunction {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] inputLine = scanner.nextLine().split("\\s+");
        Long[] numbers = new Long[inputLine.length];
        for (int i = 0; i < inputLine.length; i++) {
            numbers[i] = Long.valueOf(inputLine[i]);
        }

        Function<Long[], Long> minFunction = nums -> {
            long min = numbers[0];
            for (int i = 1; i < numbers.length; i++) {
                long currentNum = numbers[i];
                if (currentNum < min) {
                    min = currentNum;
                }
            }

            return min;
        };


        long minNumber = minFunction.apply(numbers);
        System.out.println(minNumber);
    }
}