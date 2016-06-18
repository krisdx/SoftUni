package manualStringProcessing;

import java.util.Scanner;

public class Problem6_CountSubstringOccurrences {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine().toLowerCase();
        String searchStr = scanner.nextLine().toLowerCase();

        int count = 0;
        int index = text.indexOf(searchStr);
        while (index != -1) {
            count++;
            index = text.indexOf(searchStr, index + 1);
        }

        System.out.println(count);
    }
}