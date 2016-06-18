package manualStringProcessing;

import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class Problem11_Palindromes {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] words = scanner.nextLine().split("[\\s,.?!]+");

        Set<String> uniquePalindromes = new TreeSet<>();

        for (int i = 0; i < words.length; i++) {
            if (isPalindrome(words[i]) &&
                    !uniquePalindromes.contains(words[i])) {
                uniquePalindromes.add(words[i]);
            }
        }

        System.out.println(uniquePalindromes);
    }

    private static boolean isPalindrome(String word) {
        int left = 0;
        int right = word.length() - 1;
        while (left <= right) {
            if (word.charAt(left) != word.charAt(right)) {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}