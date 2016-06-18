package setsAndMaps;

import java.util.Scanner;

public class Problem21_ParkingSystem {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int rows = input.nextInt();
        int cols = input.nextInt();
        input.nextLine();

        boolean[][] takenPlaces = new boolean[rows][cols];

        while (true) {
            String line = input.nextLine();
            if (line.equals("stop")) {
                break;
            }

            String[] params = line.split(" ");
            int entryRow = Integer.valueOf(params[0]);
            int desiredRow = Integer.valueOf(params[1]);
            int desiredCol = Integer.valueOf(params[2]);

            if (takenPlaces[desiredRow][desiredCol]) {
                int freePlace = getFreePlaceOnRow(takenPlaces, desiredRow, desiredCol);
                if (freePlace == -1) {
                    System.out.printf("Row %d full%n", desiredRow);
                } else {
                    int stepsTaken = Math.abs(entryRow - desiredRow) + 1 + freePlace;
                    takenPlaces[desiredRow][freePlace] = true;
                    System.out.println(stepsTaken);
                }
            } else {
                int stepsTaken = Math.abs(entryRow - desiredRow) + 1 + desiredCol;
                takenPlaces[desiredRow][desiredCol] = true;
                System.out.println(stepsTaken);
            }
        }
    }

    public static int getFreePlaceOnRow(boolean[][] takenPlaces, int desiredRow, int desiredCol) {
        int left = desiredCol - 1;
        int right = desiredCol + 1;

        while (left > 0 || right < takenPlaces[desiredRow].length) {
            if (left > 0) {
                if (!takenPlaces[desiredRow][left]) {
                    return left;
                }

                left--;
            }

            if (right < takenPlaces[desiredRow].length) {
                if (!takenPlaces[desiredRow][right]) {
                    return right;
                }

                right++;
            }
        }

        return -1;
    }
}