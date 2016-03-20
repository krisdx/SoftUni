import java.util.ArrayList;
import java.util.Scanner;

public class Problem4_LongestIncreasingSequence {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] strings = input.nextLine().split(" ");
        ArrayList<Integer> numbers = new ArrayList<>();
        for (int i = 0; i < strings.length; i++) {
            numbers.add(Integer.parseInt(strings[i]));
        }
        numbers.add(Integer.MIN_VALUE);

        printAllIncreasingSequences(numbers);
        printLongestIncreasingSequence(numbers);
    }

    private static void printLongestIncreasingSequence(ArrayList<Integer> numbers) {
        ArrayList<Integer> longestIncreasingSequence = new ArrayList<>();
        ArrayList<Integer> currentLongestIncreasingSequence = new ArrayList<>();

        for (int i = 0; i < numbers.size() - 1; i++) {
            if (numbers.get(i) < numbers.get(i + 1)) {
                currentLongestIncreasingSequence.add(numbers.get(i));
            } else {
                currentLongestIncreasingSequence.add(numbers.get(i));
                if (currentLongestIncreasingSequence.size() > longestIncreasingSequence.size()) {
                    longestIncreasingSequence.clear();
                    for (int j = 0; j < currentLongestIncreasingSequence.size(); j++) {
                        longestIncreasingSequence.add(currentLongestIncreasingSequence.get(j));
                    }
                }
                currentLongestIncreasingSequence.clear();
            }
        }

        System.out.printf("Longest: %s", longestIncreasingSequence);
    }

    private static void printAllIncreasingSequences(ArrayList<Integer> numbers) {
        for (int i = 0; i < numbers.size() - 1; i++) {
            int currentNum = numbers.get(i);
            int nextNum = numbers.get(i + 1);
            if (currentNum < nextNum) {
                System.out.print(currentNum + " ");
            } else {
                System.out.println(currentNum);
            }
        }
    }
}