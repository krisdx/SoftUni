import java.util.Scanner;

public class Problem7_CountSubstringOccurrences {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String inputText = input.nextLine().toLowerCase();
        String wordToSearch = input.nextLine().toLowerCase();

        int index = inputText.indexOf(wordToSearch);
        if (index == -1) {
            System.out.println(0);
            return;
        }

        int occurrencesCount = 0;
        while (index >= 0) {
            occurrencesCount++;
            index = inputText.indexOf(wordToSearch, index + 1);
        }

        System.out.println(occurrencesCount);
    }
}