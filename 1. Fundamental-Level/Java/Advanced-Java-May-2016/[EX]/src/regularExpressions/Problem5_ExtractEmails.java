package regularExpressions;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem5_ExtractEmails {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String line = scanner.nextLine();
        Pattern pattern = Pattern.compile("\\b\\s*(([0-9A-Za-z][.\\-0-9a-zA-Z]*[A-Za-z0-9])|([a-zA-z0-9]))@(([A-Za-z][-a-zA-Z]*[A-Za-z])|([A-Za-z]))(\\.(([A-Za-z][-a-zA-Z]*[A-Za-z])|([A-Za-z])))+\\b");
        Matcher matcher = pattern.matcher(line);
        if (matcher.find()) {
            System.out.println(matcher.group());
        }
    }
}