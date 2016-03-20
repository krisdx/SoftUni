package Advanced_CSharp_Exam_19_July_2015;

import java.util.HashSet;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem4_RageQuit {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Pattern pattern = Pattern.compile("([^\\d]+)(\\d+)");
        Matcher matcher = pattern.matcher(input.nextLine());

        HashSet<Character> uniqueSprigs = new HashSet<>();
        StringBuilder output = new StringBuilder();
        while (matcher.find()) {
            String string = matcher.group(1);

            int count = Integer.parseInt(matcher.group(2));
            for (int i = 0; i < count; i++) {
                output.append(string.toUpperCase());
            }
        }

        for (int i = 0; i < output.length(); i++) {
            uniqueSprigs.add(output.charAt(i));
        }

        System.out.println("Unique symbols used: " + uniqueSprigs.size());
        System.out.println(output);
    }
}