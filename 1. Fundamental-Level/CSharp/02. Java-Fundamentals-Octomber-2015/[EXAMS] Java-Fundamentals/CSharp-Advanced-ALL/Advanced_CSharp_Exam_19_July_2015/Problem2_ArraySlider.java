package Advanced_CSharp_Exam_19_July_2015;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Scanner;

public class Problem2_ArraySlider {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] inputNumbers = input.nextLine().trim().split("\\s+");
        ArrayList<BigInteger> numbers = new ArrayList<>();
        for (int i = 0; i < inputNumbers.length; i++) {
            numbers.add(new BigInteger(inputNumbers[i]));
        }

        int index = 0;
        while (true) {
            String command = input.nextLine().trim();
            if (command.equals("stop")) {
                break;
            }

            String[] commandDetails = command.split("\\s+");
            int offset = Integer.parseInt(commandDetails[0]) % numbers.size();
            String operation = commandDetails[1];
            BigInteger operand = new BigInteger(commandDetails[2]);

            if (offset < 0) {
                index = (index + (offset + numbers.size())) % numbers.size();
            } else {
                index = (index + offset) % numbers.size();
            }

            if (operation.equals("&")) {
                BigInteger result = numbers.get(index).and(operand);
                numbers.set(index, result);
            } else if (operation.equals("|")) {
                BigInteger result = numbers.get(index).or(operand);
                numbers.set(index, result);
            } else if (operation.equals("^")) {
                BigInteger result = numbers.get(index).xor(operand);
                numbers.set(index, result);
            } else if (operation.equals("+")) {
                BigInteger result = numbers.get(index).add(operand);
                numbers.set(index, result);
            } else if (operation.equals("-")) {
                BigInteger result = numbers.get(index).subtract(operand);
                if (result.longValue() <= 0){
                    result = new BigInteger("0");
                }
                numbers.set(index, result);
            } else if (operation.equals("*")) {
                BigInteger result = numbers.get(index).multiply(operand);
                numbers.set(index, result);
            } else if (operation.equals("/")) {
                BigInteger result = numbers.get(index).divide(operand);
                numbers.set(index, result);
            }
        }

        System.out.println(numbers);
    }
}