package manualStringProcessing;

import java.util.Scanner;

public class Problem12_CharacterMultiplier {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String firstStr = scanner.next();
        String secondStr = scanner.next();

        long result = getResult(firstStr, secondStr);
        System.out.println(result);
    }

    private static long getResult(String firstStr, String secondStr) {
        long result = 0;


        int minLength = Math.min(firstStr.length(), secondStr.length());
        for (int i = 0; i < minLength; i++) {
            result += firstStr.charAt(i) * secondStr.charAt(i);
        }

        String longerStr = firstStr.length() < secondStr.length() ?
                secondStr : firstStr;
        int maxLength = Math.max(firstStr.length(), secondStr.length());
        for (int i = minLength; i < maxLength; i++) {
            result += (int) longerStr.charAt(i);
        }

        return result;
    }
}