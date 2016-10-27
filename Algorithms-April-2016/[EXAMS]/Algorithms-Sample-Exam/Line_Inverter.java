import java.util.Scanner;

public class Line_Inverter {

    private static final boolean WHITE = false;
    private static final boolean BLACK = true;

    private static boolean matrix[][];

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.valueOf(scanner.nextLine());

        matrix = new boolean[n][n];
        for (int i = 0; i < n; i++) {
            String row = scanner.nextLine();
            for (int j = 0; j < n; j++) {
                matrix[i][j] = (row.charAt(j) == 'B');
            }
        }

        int movesCount = 0;
        while (movesCount < n * n) {
            int maxWhiteCellsCountByCol = 0;
            int colIndex = -1;
            for (int col = 0; col < n; col++) {
                int currentColWhiteCellsCount = 0;
                for (int row = 0; row < n; row++) {
                    if (matrix[row][col] == WHITE) {
                        currentColWhiteCellsCount++;
                    }
                }

                if (currentColWhiteCellsCount > maxWhiteCellsCountByCol) {
                    maxWhiteCellsCountByCol = currentColWhiteCellsCount;
                    colIndex = col;
                }
            }

            int maxWhiteCellsCountByRow = 0;
            int rowIndex = -1;
            for (int row = 0; row < n; row++) {
                int currentRowWhiteCellsCount = 0;
                for (int col = 0; col < n; col++) {
                    if (matrix[row][col] == WHITE) {
                        currentRowWhiteCellsCount++;
                    }
                }

                if (currentRowWhiteCellsCount > maxWhiteCellsCountByRow) {
                    maxWhiteCellsCountByRow = currentRowWhiteCellsCount;
                    rowIndex = row;
                }
            }

            if (maxWhiteCellsCountByCol == 0 && maxWhiteCellsCountByRow == 0) {
                // The matrix is all black. Found a solution.
                break;
            }

            if (maxWhiteCellsCountByCol > maxWhiteCellsCountByRow) {
                invertCol(colIndex);
            } else {
                invertRow(rowIndex);
            }

            movesCount++;
            if (movesCount == n * n) {
                // No solution.
                movesCount = -1;
                break;
            }
        }

        System.out.println(movesCount);
    }

    private static void invertCol(int colIndex) {
        for (int row = 0; row < matrix.length; row++) {
            matrix[row][colIndex] = !matrix[row][colIndex];
        }
    }

    private static void invertRow(int rowIndex) {
        for (int col = 0; col < matrix[rowIndex].length; col++) {
            matrix[rowIndex][col] = !matrix[rowIndex][col];
        }
    }
}