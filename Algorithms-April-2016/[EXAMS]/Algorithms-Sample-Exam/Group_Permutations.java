import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;

public class GroupPermutations {
	
    private static Map<Character, Integer> letters = new LinkedHashMap<>();
    private static StringBuilder output = new StringBuilder();

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        for (Character ch : input.toCharArray()) {
            if (!letters.containsKey(ch)) {
                letters.put(ch, 0);
            }

            letters.put(ch, letters.get(ch) + 1);
        }

        Set<Character> charSet = letters.keySet();
        char[] charArr = new char[charSet.size()];
        int i = 0;
        for (Character character : charSet) {
            charArr[i++] = character;
        }
        GeneratePermutations(charArr, 0);
        System.out.println(output.toString().trim());
    }

    private static void GeneratePermutations(char[] arr, int startIndex) {
        if (startIndex >= arr.length) {
            for (int i = 0; i < arr.length; i++) {
                for (int j = 0; j < letters.get(arr[i]); j++) {
                    output.append(arr[i]);
                }
            }

            output.append("\n");
            return;
        }

        for (int currentIndex = startIndex; currentIndex < arr.length; currentIndex++) {
            Swap(arr, currentIndex, startIndex);
            GeneratePermutations(arr, startIndex + 1);
            Swap(arr, currentIndex, startIndex);
        }
    }

    private static void Swap(char[] arr, int firstIndex, int secondIndex) {
        char swapValue = arr[firstIndex];
        arr[firstIndex] = arr[secondIndex];
        arr[secondIndex] = swapValue;
    }
}