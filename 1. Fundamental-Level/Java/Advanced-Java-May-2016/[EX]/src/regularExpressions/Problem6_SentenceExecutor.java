package regularExpressions;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem6_SentenceExecutor {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String word = scanner.nextLine();
        Pattern pattern = Pattern.compile(String.format("[\\w\\s]+\\b%s\\b.+?[?!.]", word));
        Matcher matcher = pattern.matcher(scanner.nextLine());
        while (matcher.find()) {
            System.out.println(matcher.group());
        }
    }
}