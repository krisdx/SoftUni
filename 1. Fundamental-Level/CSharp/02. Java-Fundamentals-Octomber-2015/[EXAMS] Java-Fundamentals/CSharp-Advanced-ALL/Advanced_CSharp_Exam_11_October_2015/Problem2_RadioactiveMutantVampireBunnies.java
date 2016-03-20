package Advanced_CSharp_Exam_11_October_2015;

import java.util.Scanner;

public class Problem2_RadioactiveMutantVampireBunnies {

    private static int playerRow = 0;
    private static int playerCol = 0;

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] matrixSize = input.nextLine().split("\\s+");
        int matrixRows = Integer.parseInt(matrixSize[0]);
        int matrixCols = Integer.parseInt(matrixSize[1]);

        char[][] matrix = new char[matrixRows][matrixCols];
        for (int i = 0; i < matrixRows; i++) {
            matrix[i] = input.nextLine().toCharArray();
        }

        getPlayerPosition(matrix);

        String commands = input.nextLine();
        boolean playerEscaped = false;
        boolean playerDied = false;
        for (int i = 0; i < commands.length() && !playerEscaped && !playerDied; i++) {
            char direction = commands.charAt(i);

            if (direction == 'U') {
                matrix[playerRow][playerCol] = '.';
                playerRow--;
                if (playerRow < 0) {
                    playerEscaped = true;
                    playerRow++;
                }
            } else if (direction == 'R') {
                matrix[playerRow][playerCol] = '.';
                playerCol++;
                if (playerCol > matrixCols - 1) {
                    playerEscaped = true;
                    playerCol--;
                }
            } else if (direction == 'L') {
                matrix[playerRow][playerCol] = '.';
                playerCol--;
                if (playerCol < 0) {
                    playerEscaped = true;
                    playerCol++;
                }
            } else if (direction == 'D') {
                matrix[playerRow][playerCol] = '.';
                playerRow++;
                if (playerRow > matrix.length - 1) {
                    playerEscaped = true;
                    playerRow--;
                }
            }
            if (!playerEscaped && matrix[playerRow][playerCol] == 'B'){
                playerDied = true;
            }

            if (!playerEscaped && !playerDied) {
                matrix[playerRow][playerCol] = 'P';
                playerDied = false;
                playerEscaped = false;
            }

            multiplyBunnies(matrix);
            if (!playerEscaped && matrix[playerRow][playerCol] == 'B'){
                playerDied = true;
            }
        }

        printMatrix(matrix);
        if (playerDied && !playerEscaped) {
            System.out.printf("dead: %d %d", playerRow, playerCol);
        } else if (!playerDied && playerEscaped) {
            System.out.printf("won: %d %d", playerRow, playerCol);
        }
    }

    private static void printMatrix(char[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                System.out.print(matrix[row][col]);
            }
            System.out.println();
        }
    }

    private static void multiplyBunnies(char[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                if (matrix[row][col] == 'B') {
                    if (row + 1 <= matrix.length - 1 && matrix[row + 1][col] != 'B') {
                        matrix[row + 1][col] = 'b';
                    }
                    if (row - 1 >= 0 && matrix[row - 1][col] != 'B') {
                        matrix[row - 1][col] = 'b';
                    }
                    if (col + 1 <= matrix[row].length - 1 && matrix[row][col + 1] != 'B') {
                        matrix[row][col + 1] = 'b';
                    }
                    if (col - 1 >= 0 && matrix[row][col - 1] != 'B') {
                        matrix[row][col - 1] = 'b';
                    }
                }
            }
        }

        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                matrix[row][col] = Character.toUpperCase(matrix[row][col]);
            }
        }
    }

    private static void getPlayerPosition(char[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                if (matrix[row][col] == 'P') {
                    matrix[row][col] = '.';
                    playerRow = row;
                    playerCol = col;
                    break;
                }
            }
        }
    }
}