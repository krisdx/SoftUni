package setsAndMaps;

import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class Problem3_PeriodicTable {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Set<String> uniqueElements = new TreeSet<>();
        int n = Integer.parseInt(input.nextLine());
        for (int i = 0; i < n; i++) {
            String[] elements = input.nextLine().split("\\s+");
            for (int j = 0; j < elements.length; j++) {
                uniqueElements.add(elements[j]);
            }
        }

        for (String uniqueElement : uniqueElements) {
            System.out.print(uniqueElement + " ");
        }
    }
}