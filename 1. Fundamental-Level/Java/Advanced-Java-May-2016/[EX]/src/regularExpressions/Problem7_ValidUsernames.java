package regularExpressions;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem7_ValidUsernames {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<String> words = new ArrayList<>();

        Pattern pattern = Pattern.compile("\\b[a-zA-Z][\\w]{2,24}\\b");
        Matcher matcher = pattern.matcher(scanner.nextLine());

        while (matcher.find()) {
            words.add(matcher.group(0));
        }

        words.add("");
        int firstWordIndex = -1;
        int secondWordIndex = -1;
        int biggestLengthSum = Integer.MIN_VALUE;
        for (int i = 0; i < words.size() - 1; i++) {
            int firstWordLength = words.get(i).length();
            int secondWordLength = words.get(i + 1).length();
            if (firstWordLength + secondWordLength > biggestLengthSum) {
                biggestLengthSum = firstWordLength + secondWordLength;
                firstWordIndex = i;
                secondWordIndex = i + 1;
            }
        }

        System.out.println(words.get(firstWordIndex));
        System.out.println(words.get(secondWordIndex));
    }
}