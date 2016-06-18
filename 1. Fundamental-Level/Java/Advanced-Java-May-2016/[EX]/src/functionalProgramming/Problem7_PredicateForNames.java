package functionalProgramming;

import java.util.Scanner;
import java.util.function.Predicate;

public class Problem7_PredicateForNames {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int length = Integer.valueOf(scanner.nextLine());
        Predicate<String> lengthPredicate = name -> name.length() <= length;

        String[] names = scanner.nextLine().split("\\s+");
        for (int i = 0; i < names.length; i++) {
            if (lengthPredicate.test(names[i])) {
                System.out.println(names[i]);
            }
        }
    }
}