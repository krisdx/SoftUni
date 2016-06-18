package streamAPI;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem12_LittleJohn {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Pattern pattern = Pattern.compile(">>>----->>|>>----->|>----->");

        int smallArrowsCount = 0;
        int mediumArrowsCount = 0;
        int largeArrowsCount = 0;
        for (int i = 0; i < 4; i++) {
            String inputLine = scanner.nextLine();

            Matcher matcher = pattern.matcher(inputLine);
            while (matcher.find()) {
                switch (matcher.group()) {
                    case ">----->":
                        smallArrowsCount++;
                        break;
                    case ">>----->":
                        mediumArrowsCount++;
                        break;
                    case ">>>----->>":
                        largeArrowsCount++;
                        break;
                }
            }
        }

        String numberInString = "" + smallArrowsCount + mediumArrowsCount + largeArrowsCount;
        Long numberInLong = Long.valueOf(numberInString);
        String binaryRepresentation = Long.toBinaryString(numberInLong);
        long resultNum = getNumber(binaryRepresentation);

        System.out.println(resultNum);
    }

    private static long getNumber(String binaryRepresentation) {
        StringBuilder result = new StringBuilder();
        for (int i = binaryRepresentation.length() - 1; i >= 0; i--) {
            result.append(binaryRepresentation.charAt(i));
        }

        String resultInString = binaryRepresentation + result.toString();
        return Long.valueOf(resultInString, 2);
    }
}