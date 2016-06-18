package manualStringProcessing;

import java.util.Scanner;

public class Problem10_UnicodeCharacters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String str = scanner.nextLine();
        for (int i = 0; i < str.length(); i++) {
            System.out.print("\\u" + Integer.toHexString(str.charAt(i) | 0x10000).substring(1));
        }
    }

    private static String toUnicode(char ch) {
        return String.format("\\u%04x", (int) ch);
    }
}