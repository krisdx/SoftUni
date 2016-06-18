package manualStringProcessing;

import java.util.Scanner;

public class Problem3_FormattingNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int a = scanner.nextInt();
        String hex = Integer.toHexString(a).toUpperCase();

        double b = scanner.nextDouble();
        String binary = getBinary(a);

        double c = scanner.nextDouble();
        System.out.printf("|%-10s|%10s|%10.2f|%-10.3f|%n",
                hex, binary, b, c);
    }

    private static String getBinary(int a) {
        String binary = Integer.toBinaryString(a);
        if (binary.length() > 10){
            binary = binary.substring(0, 10);
        }

        char[] binaryArray = new char[10];

        int end = 10 - binary.length();
        for (int i = 0; i < end; i++) {
            binaryArray[i] = '0';
        }

        int index = 0;
        for (int i = end; i < 10; i++) {
            binaryArray[i] = binary.charAt(index);
            index++;
        }

        return new String(binaryArray);
    }
}