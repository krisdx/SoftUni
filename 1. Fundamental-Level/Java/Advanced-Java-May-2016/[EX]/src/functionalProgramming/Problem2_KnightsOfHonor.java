package functionalProgramming;

import java.util.Scanner;
import java.util.function.Consumer;

public class Problem2_KnightsOfHonor {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] names = scanner.nextLine().split("\\s+");

        Consumer<String> consumer =
                (message) -> System.out.printf("Sir %s%n", message);
        for (String name : names) {
            consumer.accept(name);
        }
    }
}