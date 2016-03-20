import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem13_GetFirstOddOrEvenElements {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] numbersInString = input.nextLine().split(" ");
        int[] numbers = new int[numbersInString.length];
        for (int i = 0; i < numbersInString.length; i++) {
            numbers[i] = Integer.parseInt(numbersInString[i]);
        }

        String[] command = input.nextLine().split(" ");

        List<Integer> selectedNums = new ArrayList<>();
        int count = Integer.parseInt(command[1]);
        int index = 0;
        for (int i = 0; i < numbers.length; i++) {
            if (command[2].equals("even") && numbers[i] % 2 == 0) {
                selectedNums.add(numbers[i]);
                index++;
            } else if (command[2].equals("odd") && numbers[i] % 2 == 1) {
                selectedNums.add(numbers[i]);
                index++;
            }

            if (index == count){
                break;
            }
        }

        System.out.println(selectedNums);
    }
}