package problem4_GenericSwapIntegerBox;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<Integer> numbers = new ArrayList<>();
        int n = Integer.valueOf(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            int number = Integer.valueOf(scanner.nextLine());
            numbers.add(number);
        }

        int firstSwapIndex = scanner.nextInt();
        int secondSwapIndex = scanner.nextInt();
        GenericSwapIntegerBox.swapElements(numbers, firstSwapIndex, secondSwapIndex);

        String typeName = GenericSwapIntegerBox.getValueType(numbers.get(0));
        for (Integer number : numbers) {
            System.out.printf("%s: %d%n", typeName, number);
        }
    }
}