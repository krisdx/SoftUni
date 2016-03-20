import java.util.Scanner;

public class Problem3_TheHeiganDance {

    private static final int PLAYER_STARTING_HIT_POINTS = 18500;
    private static final int HEIGAN_STARTING_HIT_POINTS = 3000000;

    private static final String[] directionToMove = {"Up", "Right", "Down", "Left"};

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        double damagePerTurn = Double.parseDouble(input.nextLine());

        char[][] matrix = new char[15][15];
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                matrix[i][j] = '.';
            }
        }

        double heiganHitPoints = HEIGAN_STARTING_HIT_POINTS;
        int playerHitPoints = PLAYER_STARTING_HIT_POINTS;

        int cloudAttackRemaining = 0;

        String lastSpellCasted = "";

        int playerRow = 15 / 2;
        int playerCol = 15 / 2;
        while (true) {
            String[] attackDetails = input.nextLine().split(" ");
            String attackType = attackDetails[0];
            int attackRow = Integer.parseInt(attackDetails[1]);
            int attackCol = Integer.parseInt(attackDetails[2]);

            heiganHitPoints -= damagePerTurn;
            if (heiganHitPoints <= 0 || playerHitPoints <= 0) {
                break;
            }

            if (playerTakesTheDamage(attackRow, attackCol, playerRow, playerCol, matrix)) {
                for (int directionToMoveIndex = 0; directionToMoveIndex < directionToMove.length; directionToMoveIndex++) {
                    if (directionToMove[directionToMoveIndex].equals("Up")) {
                        playerRow--;
                        if (playerRow < 0) {
                            playerRow++;
                            continue;
                        }

                        if (!playerTakesTheDamage(attackRow, attackCol, playerRow, playerCol, matrix)) {
                            break;
                        } else {
                            playerRow++;
                        }
                    } else if (directionToMove[directionToMoveIndex].equals("Right")) {
                        playerCol++;
                        if (playerCol == matrix.length) {
                            playerCol--;
                            continue;
                        }

                        if (!playerTakesTheDamage(attackRow, attackCol, playerRow, playerCol, matrix)) {
                            break;
                        } else {
                            playerCol--;
                        }
                    } else if (directionToMove[directionToMoveIndex].equals("Down")) {
                        playerRow++;
                        if (playerRow == matrix.length) {
                            playerRow--;
                            continue;
                        }

                        if (!playerTakesTheDamage(attackRow, attackCol, playerRow, playerCol, matrix)) {
                            break;
                        } else {
                            playerRow--;
                        }
                    } else if (directionToMove[directionToMoveIndex].equals("Left")) {
                        playerCol--;
                        if (playerCol < 0) {
                            playerCol++;
                            continue;
                        }

                        if (!playerTakesTheDamage(attackRow, attackCol, playerRow, playerCol, matrix)) {
                            break;
                        } else {
                            playerCol++;
                        }
                    }
                }
            }

            if (cloudAttackRemaining > 0) {
                playerHitPoints -= 3500;
                cloudAttackRemaining--;
            }
            if (heiganHitPoints <= 0 || playerHitPoints <= 0) {
                break;
            }

            if (playerTakesTheDamage(attackRow, attackCol, playerRow, playerCol, matrix) && heiganHitPoints > 0) {
                if (attackType.equals("Eruption")) {
                    playerHitPoints -= 6000;
                    lastSpellCasted = "Eruption";
                } else if (attackType.equals("Cloud") ||
                        attackType.equals("Plague") ||
                        attackType.equals("Plague Cloud")) {
                    playerHitPoints -= 3500;
                    cloudAttackRemaining++;
                    lastSpellCasted = "Plague Cloud";
                }
            }

            if (heiganHitPoints <= 0 || playerHitPoints <= 0) {
                break;
            }
        }

        while (cloudAttackRemaining > 0) {
            playerHitPoints -= 3500;
            cloudAttackRemaining--;
        }

        print(heiganHitPoints, playerHitPoints, lastSpellCasted, playerRow, playerCol);
    }

    private static void print(double heiganHitPoints, int playerHitPoints, String lastSpellCasted, int playerRow, int playerCol) {
        if (heiganHitPoints <= 0) {
            System.out.println("Heigan: Defeated!");
        } else {
            System.out.printf("Heigan: %.2f\n", heiganHitPoints);
        }
        if (playerHitPoints <= 0) {
            System.out.printf("Player: Killed by %s\n", lastSpellCasted);
        } else {
            System.out.printf("Player: %s\n", playerHitPoints);
        }

        System.out.printf("Final position: %d, %d\n", playerRow, playerCol);
    }

    private static boolean playerTakesTheDamage(int attackRow, int attackCol, int playerRow, int playerCol, char[][] matrix) {

        for (int row = Math.max(0, attackRow - 1); row <= Math.min(attackRow + 1, matrix.length - 1); row++) {
            for (int col = Math.max(0, attackCol - 1); col <= Math.min(attackCol + 1, matrix[row].length - 1); col++) {
                if (row == playerRow && col == playerCol) {
                    return true;
                }
            }
        }

        return false;
    }
}