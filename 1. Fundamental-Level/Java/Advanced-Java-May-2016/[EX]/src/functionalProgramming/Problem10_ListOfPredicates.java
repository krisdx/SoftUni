package functionalProgramming;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.function.Predicate;

public class Problem10_ListOfPredicates {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.valueOf(scanner.nextLine());
        String[] input = scanner.nextLine().split("\\s+");
        List<Integer> dividers = new ArrayList<>();
        for (int i = 0; i < input.length; i++) {
            dividers.add(Integer.valueOf(input[i]));
        }

        List<Integer> numbers = new ArrayList<>();
        for (int num = 1; num <= n; num++) {
            numbers.add(num);
        }

        Predicate<Integer> predicate = num -> {
            for (Integer divider : dividers) {
                if (num % divider != 0) {
                    return false;
                }
            }

            return true;
        };


        for (Integer number : numbers) {
            if (predicate.test(number)){
                System.out.print(number + " ");
            }
        }
    }
}