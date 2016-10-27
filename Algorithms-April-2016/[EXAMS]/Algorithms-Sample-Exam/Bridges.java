import java.util.Scanner;

public class Bridges {

    private static int[][] matrix;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] northInput = scanner.nextLine().split(" ");
        int[] north = new int[northInput.length];
        for (int i = 0; i < northInput.length; i++) {
            north[i] = Integer.valueOf(northInput[i]);
        }

        String[] southInput = scanner.nextLine().split(" ");
        int[] south = new int[southInput.length];
        for (int i = 0; i < southInput.length; i++) {
            south[i] = Integer.valueOf(southInput[i]);
        }

        matrix = new int[north.length + 1][south.length + 1];
        for (int i = 1; i < matrix.length; i++) {
            for (int j = 1; j < matrix[i].length; j++) {
                if (north[i - 1] == south[j - 1]) {
                    matrix[i][j] = getMax(matrix[i - 1][j], matrix[i][j - 1], matrix[i - 1][j - 1]) + 1;
                } else {
                    matrix[i][j] = getMax(matrix[i - 1][j], matrix[i][j - 1], matrix[i - 1][j - 1]);
                }
            }
        }

        System.out.println((matrix[north.length][south.length]));
    }

    private static int getMax(int p1, int p2, int p3) {
        int max = Math.max(p1, p2);
        return Math.max(max, p3);
    }
}