package functionalProgramming;

import java.util.Scanner;
import java.util.function.Consumer;

public class Problem1_ConsumerPrint {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] names = scanner.nextLine().split("\\s+");

        Consumer<String> consumer = System.out::println;
        for (String name : names) {
            consumer.accept(name);
        }
    }
}