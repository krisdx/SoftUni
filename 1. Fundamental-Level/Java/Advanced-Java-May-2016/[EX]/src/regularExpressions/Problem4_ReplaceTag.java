package regularExpressions;

import java.util.Scanner;
import java.util.regex.Pattern;

public class Problem4_ReplaceTag {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        StringBuilder sb= new StringBuilder();
        String line = scanner.nextLine();
        while(!line.equals("end")){
            sb.append(line);
            line = scanner.nextLine();
        }

        String result = sb.toString();
        result = result.replaceAll("<a", "[URL");
        result = result.replaceAll("</a>", "[/URL]");

        System.out.println(result);
    }
}