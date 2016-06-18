package regularExpressions;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem1_MatchFullName {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Pattern pattern = Pattern.compile("[A-Z][a-z]+\\s+[A-Z][a-z]+");
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