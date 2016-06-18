package ExamPractice_13June;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Problem2_JediGalaxy {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        String[] matrixArgs = reader.readLine().split("\\s+");
        int rows = Integer.valueOf(matrixArgs[0]);
        int cols = Integer.valueOf(matrixArgs[1]);

        long[][] matrix = new long[rows][cols];
        initMatrix(matrix);

        long sum = 0;
        while (true) {
            String line = reader.readLine();
            if (line.equals("Let the Force be with you")) {
                break;
            }

            String[] IvoArgs = line.split("\\s+");
            int ivoRow = Integer.valueOf(IvoArgs[0]);
            int ivoCol = Integer.valueOf(IvoArgs[1]);

            String[] evilArgs = reader.readLine().split("\\s+");
            int evilRow = Integer.valueOf(evilArgs[0]);
            int evilCol = Integer.valueOf(evilArgs[1]);

            sum += getSum(matrix, ivoRow, ivoCol, evilRow, evilCol, cols);
        }

        System.out.println(sum);
    }

    private static long getSum(long[][] matrix, int ivoRow, int ivoCol, int evilRow, int evilCol, int cols) {
        while (true) {
            if (evilRow >= 0 && evilRow < matrix.length && evilCol >= 0 && evilCol < matrix[evilRow].length) {
                matrix[evilRow][evilCol] = 0;
            }

            evilRow--;
            evilCol--;
            if (evilRow < 0 || evilCol < 0) {
                break;
            }
        }

        long sum = 0;
        while (true) {
            if (ivoRow >= 0 && ivoRow < matrix.length && ivoCol >= 0 && ivoCol < matrix[ivoRow].length) {
                sum += matrix[ivoRow][ivoCol];
            }

            ivoRow--;
            ivoCol++;
            if (ivoRow < 0 && ivoCol > cols) {
                break;
            }
        }

        return sum;
    }

    private static void initMatrix(long[][] matrix) {
        long value = 0;
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                matrix[row][col] = value;
                value++;
            }
        }
    }
}