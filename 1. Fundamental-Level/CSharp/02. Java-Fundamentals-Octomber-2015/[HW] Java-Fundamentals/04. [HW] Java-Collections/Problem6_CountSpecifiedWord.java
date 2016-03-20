import java.util.Scanner;

public class Problem6_CountSpecifiedWord {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] words = input.nextLine().split("(?i)[\\W]+");
        String wordToSearch = input.nextLine().toLowerCase();

        int occurrencesCounter = 0;
        for (int i = 0; i < words.length; i++) {
            if (words[i].toLowerCase().equals(wordToSearch)) {
                occurrencesCounter++;
            }
        }

        System.out.println(occurrencesCounter);
    }
}