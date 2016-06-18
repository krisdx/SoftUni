package setsAndMaps;

import java.util.Scanner;

public class Problem18_VampireBunnies {
    private static int playerRow;
    private static int playerCol;

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int rows = input.nextInt();
        int cols = input.nextInt();
        input.nextLine();
        Character[][] matrix = new Character[rows][cols];
        for (int i = 0; i < rows; i++) {
            String row = input.nextLine();
            for (int j = 0; j < row.length(); j++) {
                char currentChar = row.charAt(j);
                if (currentChar == 'P') {
                    playerRow = i;
                    playerCol = j;
                    matrix[i][j] = '.';
                    continue;
                }

                matrix[i][j] = currentChar;
            }
        }

        String path = input.nextLine();
        boolean hasWon = false;
        boolean hasLost = false;
        for (int i = 0; i < path.length(); i++) {
            if (hasWon || hasLost) {
                break;
            }

            char currentDirection = path.charAt(i);
            if (currentDirection == 'U') {
                playerRow--;
                if (playerRow < 0) {
                    playerRow++;
                    hasWon = true;
                } else if (matrix[playerRow][playerCol] == 'B') {
                    hasLost = true;
                }
            } else if (currentDirection == 'D') {
                playerRow++;
                if (playerRow >= matrix.length) {
                    playerRow--;
                    hasWon = true;
                } else if (matrix[playerRow][playerCol] == 'B') {
                    hasLost = true;
                }
            } else if (currentDirection == 'L') {
                playerCol--;
                if (playerCol < 0) {
                    playerCol++;
                    hasWon = true;
                } else if (matrix[playerRow][playerCol] == 'B') {
                    hasLost = true;
                }
            } else if (currentDirection == 'R') {
                playerCol++;
                if (playerCol >= matrix[playerRow].length) {
                    playerCol--;
                    hasWon = true;
                } else if (matrix[playerRow][playerCol] == 'B') {
                    hasLost = true;
                }
            }

            System.out.println();

            for (int row = 0; row < matrix.length; row++) {
                for (int col = 0; col < matrix[row].length; col++) {
                    if (matrix[row][col] == 'B') {
                        if (row + 1 < matrix.length && matrix[row + 1][col] != 'B') {
                            matrix[row + 1][col] = 'b';
                        }
                        if (row - 1 >= 0 && matrix[row - 1][col] != 'B') {
                            matrix[row - 1][col] = 'b';
                        }
                        if (col + 1 < matrix[row].length && matrix[row][col + 1] != 'B') {
                            matrix[row][col + 1] = 'b';
                        }
                        if (col - 1 >= 0 && matrix[row][col - 1] != 'B') {
                            matrix[row][col - 1] = 'b';
                        }
                    }
                }
            }

            for (int a = 0; a < matrix.length; a++) {
                for (int b = 0; b < matrix[a].length; b++) {
                    if (matrix[a][b] == 'b') {
                        matrix[a][b] = 'B';
                    }
                }
            }

            if (matrix[playerRow][playerCol] == 'B') {
                hasLost = true;
            }
        }

        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                System.out.print(matrix[i][j]);
            }

            System.out.println();
        }

        if (hasWon) {
            System.out.printf("won: %s %s%n", playerRow, playerCol);
        } else {
            System.out.printf("dead: %s %s%n", playerRow, playerCol);
        }
    }
}