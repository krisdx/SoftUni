package manualStringProcessing;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Problem13_MagicExchangeableWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String firstStr = scanner.next();
        String secondStr = scanner.next();

        boolean areExchangeable = areExchangeable(firstStr, secondStr);
        System.out.println(areExchangeable);
    }

    private static boolean areExchangeable(String firstStr, String secondStr) {
        Map<Character, Character> map = new HashMap<>();

        int minLength = Math.min(firstStr.length(), secondStr.length());
        for (int i = 0; i < minLength; i++) {
            char firstStrChar = firstStr.charAt(i);
            char secondStrChar = secondStr.charAt(i);
            if (!map.containsKey(firstStrChar)) {
                map.put(firstStrChar, secondStrChar);
            } else if (!map.get(firstStrChar).equals(secondStrChar)) {
                return false;
            }
        }

        String longerStr = firstStr.length() <= secondStr.length() ? secondStr : firstStr;
        for (int i = minLength; i < longerStr.length(); i++) {
            if (!map.containsValue(longerStr.charAt(i)) ||
                    map.containsKey(longerStr.charAt(i))){
                return false;
            }
        }

        if (firstStr.length() != secondStr.length()){
            return  false;
        }
        return true;
    }
}