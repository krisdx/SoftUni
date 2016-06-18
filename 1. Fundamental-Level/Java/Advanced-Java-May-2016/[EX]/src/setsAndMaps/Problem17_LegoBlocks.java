package setsAndMaps;

import java.util.ArrayList;
import java.util.Scanner;

public class Problem17_LegoBlocks {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = scanner.nextInt();
        scanner.nextLine();
        ArrayList<ArrayList<Integer>> resultMatrix = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            String[] row = scanner.nextLine().trim().split("\\s+");
            resultMatrix.add(new ArrayList<>());
            for (int j = 0; j < row.length; j++) {
                resultMatrix.get(i).add(Integer.valueOf(row[j]));
            }
        }

        for (int i = 0; i < n; i++) {
            String[] row = scanner.nextLine().trim().split("\\s+");
            for (int j = row.length - 1; j >= 0; j--) {
                resultMatrix.get(i).add(Integer.valueOf(row[j]));
            }
        }

        int totalCells = 0;
        boolean isRectangleMatrix = true;
        int length = resultMatrix.get(0).size();
        StringBuilder output = new StringBuilder();
        for (int row = 0; row < resultMatrix.size(); row++) {
            if (resultMatrix.get(row).size() != length) {
                isRectangleMatrix = false;
            }

            output.append('[');
            for (int col = 0; col < resultMatrix.get(row).size(); col++) {
                if (col + 1 == resultMatrix.get(row).size()) {
                    output.append(resultMatrix.get(row).get(col));
                } else {
                    output.append(resultMatrix.get(row).get(col));
                    output.append(", ");
                }

                totalCells++;
            }

            output.append(']');
            output.append("\n");
        }

        if (isRectangleMatrix) {
            System.out.print(output);
        } else {
            System.out.println("The total number of cells is: " + totalCells);
        }
    }
}