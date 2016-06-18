package setsAndMaps;

import java.util.Scanner;

public class Problem15_RubikMatrix {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int rows = scanner.nextInt();
        int cols = scanner.nextInt();

        int[][] matrix = new int[rows][cols];
        int cellValue = 1;
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                matrix[row][col] = cellValue;
                cellValue++;
            }
        }

        int n = scanner.nextInt();
        for (int i = 0; i < n; i++) {
            int num = scanner.nextInt();
            String direction = scanner.next();
            int moves = scanner.nextInt();

            if (direction.equals("up")) {
                int count = moves % rows;
                for (int j = 0; j < count; j++) {
                    rollUp(matrix, num);
                }
            } else if (direction.equals("down")) {
                int count = moves % rows;
                for (int j = 0; j < count; j++) {
                    rollDown(matrix, num);
                }
            } else if (direction.equals("left")) {
                int count = moves % cols;
                for (int j = 0; j < count; j++) {
                    rollLeft(matrix, num);
                }
            } else if (direction.equals("right")) {
                int count = moves % cols;
                for (int j = 0; j < count; j++) {
                    rollRight(matrix, num);
                }
            }
        }

        cellValue = 1;
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (matrix[row][col] != cellValue) {
                    findValue(matrix, row, col, cellValue);
                } else {
                    System.out.println("No swap required");
                }

                cellValue++;
            }
        }
    }

    private static void findValue(int[][] matrix, int row, int col, int cellValue) {
        for (int currentRow = 0; currentRow < matrix.length; currentRow++) {
            for (int currentCol = 0; currentCol < matrix[row].length; currentCol++) {
                if (matrix[currentRow][currentCol] == cellValue) {
                    System.out.printf("Swap (%d, %d) with (%d, %d)%n", row, col, currentRow, currentCol);

                    int swapValue = matrix[currentRow][currentCol];
                    matrix[currentRow][currentCol] = matrix[row][col];
                    matrix[row][col] = swapValue;
                }
            }
        }
    }

    private static void rollRight(int[][] matrix, int row) {
        int lastElement = matrix[row][matrix[row].length - 1];
        for (int col = matrix[row].length - 1; col > 0; col--) {
            matrix[row][col] = matrix[row][col - 1];
        }

        matrix[row][0] = lastElement;
    }

    private static void rollLeft(int[][] matrix, int row) {
        int firstElement = matrix[row][0];
        for (int col = 1; col < matrix[row].length; col++) {
            matrix[row][col - 1] = matrix[row][col];
        }

        matrix[row][matrix[row].length - 1] = firstElement;
    }

    private static void rollDown(int[][] matrix, int col) {
        int lastElement = matrix[matrix.length - 1][col];
        for (int row = matrix.length - 1; row > 0; row--) {
            matrix[row][col] = matrix[row - 1][col];
        }

        matrix[0][col] = lastElement;
    }

    private static void rollUp(int[][] matrix, int col) {
        int firstElement = matrix[0][col];
        for (int row = 1; row < matrix.length; row++) {
            matrix[row - 1][col] = matrix[row][col];
        }

        matrix[matrix.length - 1][col] = firstElement;
    }
}