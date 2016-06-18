package setsAndMaps;

import java.util.Scanner;

public class Problem20_TheHeiganDance {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        boolean[][] damagedCells = new boolean[15][15];
        int playerHealth = 18500;
        double heiganHealth = 3_000_000;

        int playerRow = 7;
        int playerCol = 7;
        double playerDamage = Double.valueOf(input.nextLine());

        int plagueSpellCount = 0;
        String lastSpell = "";
        while (true) {
            String[] spellArgs = input.nextLine().split(" ");
            String spellType = spellArgs[0];
            int targetRow = Integer.valueOf(spellArgs[1]);
            int targetCol = Integer.valueOf(spellArgs[2]);

            heiganHealth -= playerDamage;
            if (heiganHealth <= 0) {
                break;
            }

            setCells(damagedCells, targetRow, targetCol, true);

            if (plagueSpellCount > 0) {
                playerHealth -= 3500;
                plagueSpellCount--;
                lastSpell = "Plague Cloud";
            }

            for (int row = targetRow - 1; row <= targetRow + 1 && playerHealth > 0; row++) {
                for (int col = targetCol - 1; col <= targetCol + 1 && playerHealth > 0; col++) {
                    if (row >= 0 && row < damagedCells.length &&
                            col >= 0 && col < damagedCells[row].length) {
                        if (row == playerRow && col == playerCol) {
                            if (playerRow - 1 >= 0 &&
                                    !damagedCells[playerRow - 1][playerCol]) {
                                playerRow--;
                            } else if (playerCol + 1 < damagedCells[playerRow].length &&
                                    !damagedCells[playerRow][playerCol + 1]) {
                                playerCol++;
                            } else if (playerRow + 1 < damagedCells.length &&
                                    !damagedCells[playerRow + 1][playerCol]) {
                                playerRow++;
                            } else if (playerCol - 1 >= 0 &&
                                    !damagedCells[playerRow][playerCol - 1]) {
                                playerCol--;
                            } else {
                                if (spellType.equals("Cloud")) {
                                    playerHealth -= 3500;
                                    lastSpell = "Plague Cloud";
                                    plagueSpellCount++;
                                } else {
                                    lastSpell = "Eruption";
                                    playerHealth -= 6000;
                                }
                            }
                        }
                    }
                }
            }

            if (playerHealth <= 0) {
                break;
            }

            setCells(damagedCells, targetRow, targetCol, false);
        }

        while (plagueSpellCount > 0) {
            playerHealth -= 3500;
            plagueSpellCount--;
            lastSpell = "Plague Cloud";
        }

        if (heiganHealth > 0) {
            System.out.printf("Heigan: %.2f%n", heiganHealth);
        } else {
            System.out.println("Heigan: Defeated!");
        }

        if (playerHealth > 0) {
            System.out.printf("Player: %s%n", playerHealth);
        } else {
            System.out.printf("Player: Killed by %s%n", lastSpell);
        }

        System.out.printf("Final position: %d, %d%n", playerRow, playerCol);
    }

    private static void setCells(boolean[][] damagedCells, int targetRow, int targetCol, boolean isDamaged) {
        for (int row = targetRow - 1; row <= targetRow + 1; row++) {
            for (int col = targetCol - 1; col <= targetCol + 1; col++) {
                if (row >= 0 && row < damagedCells.length &&
                        col >= 0 && col < damagedCells[row].length) {
                    damagedCells[row][col] = isDamaged;
                }
            }
        }
    }
}