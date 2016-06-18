package functionalProgramming;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem6_ReverseAndExclude {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] inputLine = scanner.nextLine().split("\\s+");
        List<Long> numbers =new ArrayList<>();
        for (int i = 0; i < inputLine.length; i++) {
            numbers.add(Long.valueOf(inputLine[i]));
        }

        List<Long> reversedNumbers = new ArrayList<>();
        for (int i =  numbers.size() - 1; i >=0; i--) {
            reversedNumbers.add(numbers.get(i));
        }

        int a = scanner.nextInt();
        reversedNumbers.stream().filter(x -> x % a != 0).forEach(x -> System.out.print(x + " "));
    }
}