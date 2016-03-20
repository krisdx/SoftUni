import java.util.ArrayList;
import java.util.Scanner;

public class LargestRectangle {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        ArrayList<String[]> matrix = new ArrayList<>();
        while (true) {
            String inputRow = input.nextLine();
            if (inputRow.equals("END")) {
                break;
            }

            String[] rowStrings = inputRow.replaceAll(",", " ").trim().split("\\s+");
            matrix.add(rowStrings);
        }

        int maxRectangleArea = 0;
        int[] maxRectangleAngles = new int[4];
        for (int y1 = 0; y1 < matrix.size(); y1++) {
            for (int x1 = 0; x1 < matrix.get(y1).length; x1++) {
                for (int y2 = y1; y2 < matrix.size(); y2++) {
                    for (int x2 = x1; x2 < matrix.get(y2).length; x2++) {
                        if (areElementsEqual(y1, x1, y2, x2, matrix)) {
                            int currentRectangleArea = (x2 + 1 - x1 + 1) * (y2 + 1 - y1 + 1);

                            if (currentRectangleArea > maxRectangleArea) {
                                maxRectangleArea = currentRectangleArea;
                                maxRectangleAngles = new int[]{y1, x1, y2, x2};
                            }
                        }
                    }
                }
            }
        }

        markCells(maxRectangleAngles, matrix);

        print(matrix);
    }

    private static void print(ArrayList<String[]> matrix) {
        for (int row = 0; row < matrix.size(); row++) {
            for (int col = 0; col < matrix.get(row).length; col++) {
                System.out.printf("%5s", matrix.get(row)[col]);
            }
            System.out.println();
        }
    }

    private static void markCells(int[] maxRectangleAngles, ArrayList<String[]> matrix) {
        int minRow = maxRectangleAngles[0];
        int minCol = maxRectangleAngles[1];
        int maxRow = maxRectangleAngles[2];
        int maxCol = maxRectangleAngles[3];

        for (int col = minCol; col <= maxCol; col++) {
            matrix.get(minRow)[col] = "[" + matrix.get(minRow)[col] + "]";
            matrix.get(maxRow)[col] = "[" + matrix.get(maxRow)[col] + "]";
        }

        for (int row = minRow + 1; row < maxRow; row++) {
            matrix.get(row)[minCol] = "[" + matrix.get(row)[minCol] + "]";
            matrix.get(row)[maxCol] = "[" + matrix.get(row)[maxCol] + "]";
        }
    }

    private static boolean areElementsEqual(int minRow, int minCol, int maxRow, int maxCol, ArrayList<String[]> matrix) {
        String element = matrix.get(minRow)[minCol];

        for (int col = minCol; col <= maxCol; col++) {
            if (!matrix.get(minRow)[col].equals(element)) {
                return false;
            }

            if (!matrix.get(maxRow)[col].equals(element)) {
                return false;
            }
        }

        for (int row = minRow; row <= maxRow; row++) {
            if (!matrix.get(row)[minCol].equals(element)) {
                return false;
            }

            if (!matrix.get(row)[maxCol].equals(element)) {
                return false;
            }
        }

        return true;
    }
}