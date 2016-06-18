package regularExpressions;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem2_MatchPhoneNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Pattern pattern = Pattern.compile("\\+359(\\-|\\s)2\\1\\d{3}\\1\\d{4}\\b");
        String line = scanner.nextLine();
        while (!line.equals("end")){
            Matcher matcher = pattern.matcher(line);
            if  (matcher.find()){
                System.out.println(matcher.group(0));
            }

            line = scanner.nextLine();
        }
    }
}
