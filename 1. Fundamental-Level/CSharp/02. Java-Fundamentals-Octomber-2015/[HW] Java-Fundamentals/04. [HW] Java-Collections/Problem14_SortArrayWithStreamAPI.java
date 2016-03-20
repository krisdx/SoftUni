import java.util.ArrayList;
import java.util.Comparator;
import java.util.Scanner;

public class Problem14_SortArrayWithStreamAPI {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] numbersInString = input.nextLine().split(" ");
        String order = input.nextLine();

        ArrayList<Integer> numbers = new ArrayList<>();
        for (int i = 0; i < numbersInString.length; i++) {
            numbers.add(Integer.parseInt(numbersInString[i]));
        }

        if (order.equals("Ascending")) {
            numbers.stream()
                    .sorted()
                    .forEach(num -> System.out.print(num + " "));
        } else {
            numbers.stream()
                    .sorted(Comparator.reverseOrder())
                    .forEach(num -> System.out.print(num + " "));
        }
    }
}