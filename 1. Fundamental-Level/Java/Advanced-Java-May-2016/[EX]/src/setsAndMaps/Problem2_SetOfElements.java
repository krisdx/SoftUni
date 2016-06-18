package setsAndMaps;

import java.util.LinkedHashSet;
import java.util.Scanner;
import java.util.Set;

public class Problem2_SetOfElements {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();
        int m = input.nextInt();

        Set<Integer> firstSet = new LinkedHashSet<>();
        for (int i = 0; i < n; i++) {
            firstSet.add(input.nextInt());
        }

        for (int i = 0; i < m; i++) {
            int number = input.nextInt();
            if (firstSet.contains(number)) {
                System.out.print(number + " ");
            }
        }
    }
}