import java.util.HashSet;
import java.util.Scanner;

public class Problem2_SequencesOfEqualStrings {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] strings = input.nextLine().split(" ");
        HashSet<String> uniqueStrings = new HashSet<>();

        for (int i = 0; i < strings.length; i++) {
            String currentString = strings[i];

            if (!uniqueStrings.contains(currentString)) {
                System.out.print(currentString + " ");
                for (int j = i + 1; j < strings.length; j++) {
                    if (strings[j].equals(currentString)) {
                        System.out.print(strings[j] + " ");
                    }
                }
                System.out.println();

                uniqueStrings.add(currentString);
            }
        }
    }
}