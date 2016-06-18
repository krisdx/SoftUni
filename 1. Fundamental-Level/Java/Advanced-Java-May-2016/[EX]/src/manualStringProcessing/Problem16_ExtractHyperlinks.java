package manualStringProcessing;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem16_ExtractHyperlinks {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        StringBuilder sb = new StringBuilder();
        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            sb.append(line);
        }

        Pattern pattern = Pattern.compile("<a\\s+[^>]*href\\s*=\\s*(?:\"([^\"]*)\"|'([^']*)'|([^>\\s]+))");
        Matcher matcher = pattern.matcher(sb.toString());
        while (matcher.find()) {
            if (matcher.group(1) != null) {
                System.out.println(matcher.group(1));
            } else if (matcher.group(2) != null) {
                System.out.println(matcher.group(2));
            } else if (matcher.group(3) != null) {
                System.out.println(matcher.group(3));
            }
        }
    }
}
