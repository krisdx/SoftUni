package problem3_GenericSwapMethodString;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<String> list = new ArrayList<>();
        int n = Integer.valueOf(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            list.add(scanner.nextLine());
        }

        int firstSwapIndex = scanner.nextInt();
        int secondSwapIndex = scanner.nextInt();
        GenericSwapStringBox.swapElements(list, firstSwapIndex, secondSwapIndex);

        String typeName = GenericSwapStringBox.getValueType(list.get(0));
        for (String str : list) {
            System.out.printf("%s: %s%n", typeName, str);
        }
    }
}