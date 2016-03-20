import java.util.Arrays;
import java.util.Scanner;

public class Problem1_SortArrayOfNumbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++) {
            numbers[i] = input.nextInt();
        }

        sortArray(numbers);
        for (int i = 0; i < numbers.length; i++) {
            System.out.print(numbers[i] + " ");
        }
    }

    private static void sortArray(int[] numbers) {
        // Bubble sort algorithm
        while (true) {
            boolean areSorted = true;
            for (int i = 0; i < numbers.length - 1; i++) {
                if (numbers[i] > numbers[i + 1]) {
                    int exchangeValue = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = exchangeValue;
                    areSorted = false;
                }
            }
            if (areSorted) {
                break;
            }
        }
    }
}