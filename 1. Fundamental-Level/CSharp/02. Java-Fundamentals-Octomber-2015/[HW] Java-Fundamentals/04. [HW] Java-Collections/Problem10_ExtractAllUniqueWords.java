import java.util.Scanner;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem10_ExtractAllUniqueWords {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] words = input.nextLine().toLowerCase().split("\\W+");

        TreeSet<String> uniqueWords = new TreeSet<>();
        for (int i = 0; i < words.length; i++) {
            uniqueWords.add(words[i]);
        }

        System.out.println(uniqueWords);
    }
}