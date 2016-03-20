import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Problem14_MagicExchangeableWords {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String firstString = input.next();
        String secondString = input.next();
        if (firstString.length() != secondString.length()) {
            System.out.println("The lengths of the string are not equal.");
            return;
        }

        System.out.println(areStringExchangeable(firstString, secondString));
    }

    private static boolean areStringExchangeable(String firstString, String secondString) {
        Map<Character, Character> usedChars = new HashMap<>();

        for (int i = 0; i < firstString.length(); i++) {
            char key = firstString.charAt(i);
            char value = secondString.charAt(i);

            if (usedChars.containsKey(key) && !usedChars.containsValue(value)) {
                return false;
            }

            usedChars.put(firstString.charAt(i), secondString.charAt(i));
        }

        return true;
    }
}