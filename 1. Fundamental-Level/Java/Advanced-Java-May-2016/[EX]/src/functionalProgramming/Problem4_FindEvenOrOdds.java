package functionalProgramming;

import java.util.*;
import java.util.function.Predicate;

public class Problem4_FindEvenOrOdds {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] input = scanner.nextLine().split("\\s+");
        long startRange = Long.valueOf(input[0]);
        long endRange = Long.valueOf(input[1]);
        Set<Long> numbers = new TreeSet<>();
        for (long num = startRange; num <= endRange; num++) {
            numbers.add(num);
        }

        Predicate<Long> isOddPredicate = num -> Math.abs(num) % 2 == 1;
        Predicate<Long> isEvenPredicate = num -> Math.abs(num) % 2 == 0;

        String isOdd = scanner.nextLine();
        if (isOdd.equals("odd")) {
            numbers.stream().filter(isOddPredicate).forEach(x -> System.out.print(x + " "));
        } else {
            numbers.stream().filter(isEvenPredicate).forEach(x -> System.out.print(x + " "));
        }
        System.out.println();
    }
}