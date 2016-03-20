package Advanced_CSharp_Exam_19_July_2015;

import java.util.Scanner;

public class Problem1_BunkerBuster {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] matrixSize = input.nextLine().split("\\s+");
        int matrixRows = Integer.parseInt(matrixSize[0]);
        int matrixCols = Integer.parseInt(matrixSize[1]);

        int[][] matrix = new int[matrixRows][matrixCols];
        for (int i = 0; i < matrixRows; i++) {
            String[] row = input.nextLine().split("\\s+");
            for (int j = 0; j < row.length; j++) {
                matrix[i][j] = Integer.parseInt(row[j]);
            }
        }

        while (true) {
            String command = input.nextLine();
            if (command.equals("cease fire!")) {
                break;
            }

            String[] commandDetails = command.split("\\s+");
            int bombRow = Integer.parseInt(commandDetails[0]);
            int bombCol = Integer.parseInt(commandDetails[1]);
            char power = commandDetails[2].charAt(0);
            double damage = (int) power;

            doDamage(matrix, bombRow, bombCol, damage);
        }

        int destroyedBunkers = getDestroyedCells(matrix);
        System.out.println("Destroyed bunkers: " + destroyedBunkers);
        System.out.printf("Damage done: %.1f %%", ((double) destroyedBunkers / (matrixRows * matrixCols)) * 100);

    }

    private static int getDestroyedCells(int[][] matrix) {
        int destroyedCellsCount = 0;
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                if (matrix[row][col] <= 0) {
                    destroyedCellsCount++;
                }
            }
        }

        return destroyedCellsCount;
    }

    private static void doDamage(int[][] matrix, int bombRow, int bombCol, double damage) {
        int minRow = Math.max(0, bombRow - 1);
        int maxRow = Math.min(bombRow + 1, matrix.length - 1);
        int minCol = Math.max(0, bombCol - 1);
        int maxCol = Math.min(bombCol + 1, matrix[bombRow].length - 1);

        for (int row = minRow; row <= maxRow; row++) {
            for (int col = minCol; col <= maxCol; col++) {
                if (row == bombRow && col == bombCol) {
                    matrix[row][col] -= damage;
                } else {
                    matrix[row][col] -= Math.round(damage / 2);
                }
            }
        }
    }
}