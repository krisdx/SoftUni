package manualStringProcessing;

import java.util.Scanner;

public class Problem9_TextFilter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] bannedWords = scanner.nextLine().split(", ");
        String text = scanner.nextLine();
        for (int i = 0; i < bannedWords.length; i++) {
            String replacementString = getString(bannedWords[i].length());
            text = text.replaceAll(bannedWords[i], replacementString);
        }

        System.out.println(text);
    }

    private static String getString(int length) {
        char[] str = new char[length];
        for (int i = 0; i < length; i++) {
            str[i] = '*';
        }

        return new String(str);
    }
}