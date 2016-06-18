package regularExpressions;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem10_UseYourChainsBuddy {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();
        List<String> result = new ArrayList<>();

        Pattern pattern = Pattern.compile("<p>(.+?)</p>");
        Matcher matcher = pattern.matcher(text);
        while (matcher.find()) {
            String match = matcher.group(1);
            String decryptedMatch = decrypt(match);
            result.add(decryptedMatch);
        }

        for (String str : result) {
            System.out.print(str);
        }
    }

    private static String decrypt(String match) {
        StringBuilder sb = new StringBuilder(match);
        for (int i = 0; i < sb.length(); i++) {
            char currentChar = sb.charAt(i);
            if (!Character.isDigit(currentChar) &&
                    !Character.isLowerCase(currentChar)) {
                sb.setCharAt(i, ' ');
            }
        }

        for (int i = 0; i < sb.length(); i++) {
            char currentChar = sb.charAt(i);
            if (Character.isLetter(currentChar)) {
                if (currentChar >= 'a' && currentChar <= 'm') {
                    currentChar += 13;
                } else {
                    currentChar -= 13;
                }

                sb.setCharAt(i, currentChar);
            }
        }

        String result = sb.toString();
        result = result.replaceAll("\\s+", " ");

        return result;
    }
}