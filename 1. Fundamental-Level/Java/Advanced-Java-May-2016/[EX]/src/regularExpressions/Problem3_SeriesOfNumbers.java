package regularExpressions;

import java.util.Scanner;
import java.util.regex.Pattern;

public class Problem3_SeriesOfNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String line = scanner.nextLine();

        for (int i = 0; i < line.length(); i++) {
            Pattern pattern = Pattern.compile(String.format("%s+", line.charAt(i)));
            Character replacement = line.charAt(i);
            line = line.replaceAll(pattern.pattern(), replacement.toString());
        }

        System.out.println(line);
    }
}