package Advanced_CSharp_Exam_31_May_2015;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem3_TextTransformer {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        StringBuilder collectedInput = new StringBuilder();
        while (true) {
            String inputLine = input.nextLine();
            if (inputLine.equals("burp")) {
                break;
            }

            collectedInput.append(inputLine);
        }

        String trimmedString = collectedInput.toString().replaceAll("\\s+", " ");

        Pattern pattern = Pattern.compile("([$%&'])(.+?)\\1");
        Matcher matcher = pattern.matcher(trimmedString);

        StringBuilder resultString = new StringBuilder();
        while (matcher.find()) {
            int specialSymbol = getValue(matcher.group(1).charAt(0));
            String importantData = matcher.group(2);

            for (int i = 0; i < importantData.length(); i++) {
                if (i % 2 == 0) {
                    resultString.append((char) (importantData.charAt(i) + specialSymbol));
                } else {
                    resultString.append((char) (importantData.charAt(i) - specialSymbol));
                }
            }
            resultString.append(" ");
        }

        System.out.println(resultString);
    }

    private static int getValue(char ch) {
        switch (ch) {
            case '$':
                return 1;
            case '%':
                return 2;
            case '&':
                return 3;
            case '\'':
                return 4;
            default:
                return -1;
        }
    }
}