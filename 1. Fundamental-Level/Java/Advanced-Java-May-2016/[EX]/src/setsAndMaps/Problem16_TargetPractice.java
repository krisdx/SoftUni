package setsAndMaps;

import java.util.Scanner;

public class Problem16_TargetPractice {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int rows = scanner.nextInt();
        int cols = scanner.nextInt();
        String str = scanner.next();

        char[][] matrix = fillMatrix(str, rows, cols);

        int attackRow = scanner.nextInt();
        int attackCol = scanner.nextInt();
        int radius = scanner.nextInt();
        shoot(matrix, attackRow, attackCol, radius);

        bringDown(matrix);
        print(matrix);
    }

    private static void bringDown(char[][] matrix) {
        for (int row = matrix.length - 1; row >= 0; row--) {
            for (int col = 0; col < matrix[row].length; col++) {
                char ch = matrix[row][col];
                matrix[row][col] = ' ';
                int tempRow = row;
                while (tempRow + 1 < matrix.length && matrix[tempRow + 1][col] == ' ') {
                    tempRow++;
                }

                matrix[tempRow][col] = ch;
            }
        }
    }

    private static void shoot(char[][] matrix, int attackRow, int attackCol, int radius) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                boolean isInRange =
                        (attackRow - row) * (attackRow - row) +
                                (attackCol - col) * (attackCol - col) <= radius * radius;
                if (isInRange) {
                    matrix[row][col] = ' ';
                }
            }
        }
    }

    private static void print(char[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                System.out.print(matrix[row][col]);
            }

            System.out.println();
        }
    }

    private static char[][] fillMatrix(String str, int rows, int cols) {
        char[][] matrix = new char[rows][cols];

        int index = 0;
        boolean leftDirection = true;
        for (int row = rows - 1; row >= 0; row--) {
            if (leftDirection) {
                for (int col = cols - 1; col >= 0; col--) {
                    matrix[row][col] = str.charAt(index);
                    index++;
                    if (index >= str.length()) {
                        index = 0;
                    }
                }
            } else {
                for (int col = 0; col < cols; col++) {
                    matrix[row][col] = str.charAt(index);
                    index++;
                    if (index >= str.length()) {
                        index = 0;
                    }
                }
            }

            leftDirection = !leftDirection;
        }

        return matrix;
    }
}