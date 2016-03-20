import java.util.Scanner;
import java.util.HashSet;

public class Problem5_CountAllWords {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] words = input.nextLine().split("[\\W]+");

        HashSet<String> uniqueWords = new HashSet<>();
        for (int i = 0; i < words.length; i++) {
            uniqueWords.add(words[i]);
        }

        // uniqueWords.forEach(System.out::println);
        System.out.printf("Unique words: %d", uniqueWords.size());
    }
}