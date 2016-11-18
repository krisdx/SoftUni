package Algorithms_Live_Exam_Preparation;

import java.util.Arrays;
import java.util.Scanner;

public class Guitar {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] inputIntervals = scanner.nextLine().split("[\\s,]+");
        int[] intervals = new int[inputIntervals.length];
        for (int i = 0; i < intervals.length; i++) {
            intervals[i] = Integer.valueOf(inputIntervals[i]);
        }

        int initialVolume = Integer.valueOf(scanner.nextLine());
        int maxVolume = Integer.valueOf(scanner.nextLine());

        boolean[] firstArr = new boolean[maxVolume + 1];
        boolean[] secondArr = new boolean[maxVolume + 1];

        firstArr[initialVolume] = true;
        for (int i = 1; i <= intervals.length; i++) {
            for (int j = 0; j <= maxVolume; j++) {
                if (firstArr[j]) {
                    if (j - intervals[i - 1] >= 0) {
                        secondArr[j - intervals[i - 1]] = true;
                    }
                    if (j + intervals[i - 1] <= maxVolume) {
                        secondArr[j + intervals[i - 1]] = true;
                    }
                }
            }

            firstArr = Arrays.copyOf(secondArr, secondArr.length);
            for (int j = 0; j < secondArr.length; j++) {
                secondArr[j] = false;
            }
        }

        for (int i = maxVolume; i >= 0; i--) {
            if (firstArr[i]) {
                System.out.println(i);
                return;
            }
        }

        System.out.println(-1);
    }
}