package Algorithms_Live_Exam_Preparation;

import java.util.Scanner;

public class Towns {

    private static int[] increasingSequenceCount;
    private static int[] decreasingSequenceCount;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.valueOf(scanner.nextLine());
        int[] citizensCount = new int[n];
        for (int i = 0; i < n; i++) {
            citizensCount[i] = Integer.valueOf(scanner.nextLine().split("\\s+")[0]);
        }

        increasingSequenceCount = new int[n];
        for (int i = 0; i < n; i++) {
            increasingSequenceCount[i] = 1;
            for (int j = 0; j < i; j++) {
                if (citizensCount[j] < citizensCount[i] &&
                        increasingSequenceCount[j] + 1 >= increasingSequenceCount[i]) {
                    increasingSequenceCount[i] = Math.max(
                            increasingSequenceCount[i],
                            increasingSequenceCount[j] + 1);
                }
            }
        }

        decreasingSequenceCount = new int[n];
        for (int i = n - 1; i >= 0; i--) {
            decreasingSequenceCount[i] = 1;
            for (int j = n - 1; j > i; j--) {
                if (citizensCount[j] < citizensCount[i] &&
                        decreasingSequenceCount[j] + 1 >= decreasingSequenceCount[i]) {
                    decreasingSequenceCount[i] = Math.max(
                            decreasingSequenceCount[i],
                            decreasingSequenceCount[j] + 1);
                }
            }
        }

        int longestPath = 0;
        for (int i = 0; i < n; i++) {
            int currentPath = increasingSequenceCount[i] + decreasingSequenceCount[i] - 1;
            if (currentPath > longestPath) {
                longestPath = currentPath;
            }
        }

        System.out.println(longestPath);
    }
}