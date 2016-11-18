package Algorithms_Live_Exam_Preparation;

import java.util.Scanner;

public class ShortestPath {

    private static char[] directions = new char[]{'L', 'R', 'S'};
    private static boolean[] starIndexes;

    private static StringBuilder output = new StringBuilder();
    private static int pathsCount;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        char[] chars = scanner.nextLine().trim().toCharArray();
        starIndexes = new boolean[chars.length];
        for (int i = 0; i < chars.length; i++) {
            if (chars[i] == '*') {
                starIndexes[i] = true;
            }
        }

        solve(chars, 0);

        System.out.println(pathsCount);
        System.out.println(output.toString().trim());
    }

    private static void solve(char[] arr, int index) {
        if (index >= arr.length) {
            output.append(arr).append(System.lineSeparator());
            pathsCount++;
            return;
        }

        if (starIndexes[index]) {
            for (char direction : directions) {
                arr[index] = direction;
                solve(arr, index + 1);
            }
        } else {
            solve(arr, index + 1);
        }
    }
}