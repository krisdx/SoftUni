import java.util.HashSet;
import java.util.Scanner;

public class Problem3_LargestSequenceOfEqualStrings {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] strings = input.nextLine().split(" ");
        HashSet<String> uniqueElements = new HashSet<>();

        String mostFrequnetString = "";
        int maxEqualElementsCount = 0;
        for (int i = 0; i < strings.length; i++) {
            String currentString = strings[i];

            if (!uniqueElements.contains(currentString)) {
                int equalCounter = 1;
                for (int j = i + 1; j < strings.length; j++) {
                    String nextString = strings[j];
                    if (currentString.equals(nextString)) {
                        equalCounter++;
                    }
                }

                if (equalCounter > maxEqualElementsCount) {
                    maxEqualElementsCount = equalCounter;
                    mostFrequnetString = currentString;
                }

                uniqueElements.add(currentString);
            }
        }

        for (int i = 0; i < maxEqualElementsCount; i++) {
            System.out.print(mostFrequnetString + " ");
        }
    }
}