package problem1_GenericBox;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<GenericStringBox<String>> boxes = new ArrayList<>();
        int n = Integer.valueOf(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            String str = scanner.nextLine();
            GenericStringBox<String> box = new GenericStringBox<>(str);
            boxes.add(box);
        }

        for (GenericStringBox<String> box : boxes) {
            System.out.printf(
                    "%s: %s%n", box.getValueType(), box);
        }
    }
}