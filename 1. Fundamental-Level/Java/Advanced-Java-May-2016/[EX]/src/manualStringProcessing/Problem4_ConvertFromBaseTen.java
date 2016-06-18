package manualStringProcessing;

import java.math.BigInteger;
import java.util.Scanner;

public class Problem4_ConvertFromBaseTen {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        BigInteger desiredNumeralSystem = new BigInteger(scanner.next());
        BigInteger number = scanner.nextBigInteger();

        StringBuilder result = new StringBuilder();
        while (!number.equals(BigInteger.ZERO)){
            BigInteger[] divisionWithReminder = number.divideAndRemainder(desiredNumeralSystem);
            number = divisionWithReminder[0];
            result.append(divisionWithReminder[1].toString().charAt(0));
        }

        StringBuilder reversedResult = new StringBuilder();
        for (int i = result.length() - 1; i >= 0; i--) {
            reversedResult.append(result.charAt(i));
        }

        BigInteger resultNumber = new BigInteger(reversedResult.toString());
        System.out.println(resultNumber);
    }
}