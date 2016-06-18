package manualStringProcessing;

import java.math.BigInteger;
import java.util.Scanner;

public class Problem5_ConvertFromBaseN {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer base = scanner.nextInt();
        String number = scanner.next();

        BigInteger result = new BigInteger("0");
        int power = 0;
        for (int i = number.length() - 1; i >= 0; i--) {
            Integer digit = Character.getNumericValue(number.charAt(i));
            BigInteger baseToPower = new BigInteger(base.toString()).pow(power);
            baseToPower = baseToPower.multiply(new BigInteger(digit.toString()));
            power++;

            result = result.add(baseToPower);
        }

        System.out.println(result);
    }
}