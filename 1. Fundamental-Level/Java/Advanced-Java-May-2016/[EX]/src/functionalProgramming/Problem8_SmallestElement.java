package functionalProgramming;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.function.Function;

public class Problem8_SmallestElement {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] inputLine = scanner.nextLine().split("\\s+");
        List<Long> numbers = new ArrayList<>();
        for (int i = 0; i < inputLine.length; i++) {
            numbers.add(Long.valueOf(inputLine[i]));
        }

        Function<List<Long>, Long> minFunction = (num) -> {
            long min = numbers.get(0);
            long minNumIndex = 0;
            for (int i = 1; i < numbers.size(); i++) {
                long currentNum = numbers.get(i);
                if (currentNum <= min) {
                    min = currentNum;
                    minNumIndex = i;
                }
            }

            return minNumIndex;
        };


        long minNumber = minFunction.apply(numbers);
        System.out.println(minNumber);
    }
}