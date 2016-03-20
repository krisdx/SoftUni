import java.util.Scanner;

public class Problem5_ConvertDecimalToBase7 {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("n = ");
        int num = input.nextInt();

        String reversedNumInString = Reverse(Integer.toString( num));
        int decimalNum = 0;
        for (int i = 0; i < reversedNumInString.length(); i++) {

            int digit = Integer.parseInt(Character.toString(reversedNumInString.charAt(i)));
            decimalNum += digit * Math.pow(7 , i);
        }

        System.out.println("10-based num: " + decimalNum);
    }

    private static String Reverse(String num) {
        String reversedNumInString = "";
        for (int i = num.length() - 1; i >= 0; i--) {
            reversedNumInString += num.charAt(i);
        }

        return reversedNumInString;
    }
}