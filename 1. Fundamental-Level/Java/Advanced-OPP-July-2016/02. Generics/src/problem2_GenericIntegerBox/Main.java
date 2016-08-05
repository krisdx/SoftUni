package problem2_GenericIntegerBox;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<GenericIntegerBox<Integer>> boxes = new ArrayList<>();
        int n = Integer.valueOf(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            Integer number = Integer.valueOf(scanner.nextLine());
            GenericIntegerBox<Integer> box = new GenericIntegerBox<>(number);
            boxes.add(box);
        }

        for (GenericIntegerBox<Integer> box : boxes) {
            System.out.printf("%s: %s%n", box.getValueType(), box);
        }
    }
}
