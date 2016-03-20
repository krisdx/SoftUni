package Advanced_CSharp_Exam_31_May_2015;

import java.util.Scanner;

public class Problem2_TargetPractice {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] matrixSizes = input.nextLine().split("\\s+");
        int matrixRows = Integer.parseInt(matrixSizes[0]);
        int matrixCols = Integer.parseInt(matrixSizes[1]);

        char[][] matrix = new char[matrixRows][matrixCols];
        String snake = input.nextLine();
        fillMatrix(matrix, snake);

        String[] shootCoordinates = input.nextLine().split("\\s+");
        int shootRow = Integer.parseInt(shootCoordinates[0]);
        int shootCol = Integer.parseInt(shootCoordinates[1]);
        int radius = Integer.parseInt(shootCoordinates[2]);

        shoot(matrix, shootRow, shootCol, radius);

        moveDownChars(matrix);

        print(matrix);
    }

    private static void print(char[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                System.out.print(matrix[row][col]);
            }
            System.out.println();
        }
    }

    private static void moveDownChars(char[][] matrix) {
        while (true) {
            boolean hasMoreCharsToMove = false;
            for (int row = 0; row < matrix.length; row++) {
                for (int col = 0; col < matrix[row].length; col++) {
                    if (row + 1 < matrix.length &&
                            matrix[row][col] != ' ' &&
                            matrix[row + 1][col] == ' ') {
                        int movedRow = row;
                        while (true) {
                            movedRow++;
                            if (movedRow + 1 >= matrix.length || matrix[movedRow + 1][col] != ' ') {
                                break;
                            }
                        }
                        hasMoreCharsToMove = true;

                        matrix[movedRow][col] = matrix[row][col];
                        matrix[row][col] = ' ';
                    }
                }
            }
            if (!hasMoreCharsToMove) {
                break;
            }
        }
    }

    private static void shoot(char[][] matrix, int shootRow, int shootCol, int radius) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                boolean isInsideShootRadius =
                        (row - shootRow) * (row - shootRow) +
                                (col - shootCol) * (col - shootCol) <= radius * radius;
                if (isInsideShootRadius) {
                    matrix[row][col] = ' ';
                }
            }
        }
    }

    private static void fillMatrix(char[][] matrix, String snake) {
        int snakeCharIndex = 0;

        boolean isLeftDirection = true;
        for (int row = matrix.length - 1; row >= 0; row--) {
            int col = isLeftDirection ? matrix[row].length - 1 : 0;
            while (col >= 0 && col < matrix[row].length) {
                matrix[row][col] = snake.charAt(snakeCharIndex);
                col = isLeftDirection ? col - 1 : col + 1;
                snakeCharIndex++;
                if (snakeCharIndex == snake.length()) {
                    snakeCharIndex = 0;
                }
            }

            isLeftDirection = !isLeftDirection;
        }
    }
}