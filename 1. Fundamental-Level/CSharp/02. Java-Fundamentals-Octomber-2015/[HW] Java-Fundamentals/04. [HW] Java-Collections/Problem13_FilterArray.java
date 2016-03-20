import java.util.ArrayList;
import java.util.Scanner;

public class Problem13_FilterArray {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] strings = input.nextLine().split(" ");

        ArrayList<String> list = new ArrayList<>();
        for (int i = 0; i < strings.length; i++) {
            list.add(strings[i]);
        }

        list.stream()
            .filter(word -> word.length() > 3)
            .forEach(word -> System.out.println(word));
    }
}
