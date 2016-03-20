import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem8_OddEvenPairs {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.print("numbers = ");
        String numbersInString = input.nextLine();
        String[] numbersInStringArray = numbersInString.split("\\s+");
        if (numbersInStringArray.length % 2 != 0) {
            System.out.println("Invalid length");
            return;
        }

        List<Integer> numbers = new ArrayList<Integer>();
        for (int i = 0; i < numbersInStringArray.length; i++) {
            numbers.add(Integer.parseInt(numbersInStringArray[i]));
        }

        for (int i = 0; i < numbers.size() - 1; i += 2) {
            int firstNum = numbers.get(i);
            int secondNum = numbers.get(i + 1);

            if (firstNum % 2 == 0 && secondNum % 2 == 0){
                System.out.printf("%s, %s -> both are even\n", firstNum, secondNum);
            } else if (firstNum % 2 == 1 && secondNum % 2 == 1){
                System.out.printf("%s, %s -> both are odd\n", firstNum, secondNum);
            } else {
                System.out.printf("%s, %s -> different\n", firstNum, secondNum);
            }
        }
    }
}