package problem6_GenericCountMethodDoubles;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<Double> elements = new ArrayList<>();
        int n = Integer.valueOf(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            double doubleNumber = Double.valueOf(scanner.nextLine());
            elements.add(doubleNumber);
        }

        Double compareElement = Double.valueOf(scanner.nextLine());
        int result = GenericStringBox.getBiggerElementsCount(elements, compareElement);
        System.out.println(result);
    }
}