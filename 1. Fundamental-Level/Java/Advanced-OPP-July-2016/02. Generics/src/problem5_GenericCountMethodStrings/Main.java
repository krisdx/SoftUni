package problem5_GenericCountMethodStrings;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<String> elements = new ArrayList<>();
        int n = Integer.valueOf(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            elements.add(scanner.nextLine());
        }

        String compareElement = scanner.nextLine();
        int result = GenericStringBox.getBiggerElementsCount(elements, compareElement);
        System.out.println(result);
    }
}