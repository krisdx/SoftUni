import java.util.Scanner;

public class Problem12_CharacterMultiplier {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String firstString = input.next();
        String secondString = input.next();

        int characterSum = MultiplyChars(firstString, secondString);
        System.out.println(characterSum);
    }

    private static int MultiplyChars(String firstString, String secondString) {
        int sum = 0;

        boolean isFirstStringBigger = firstString.length() > secondString.length();
        int smallerStringLength = Math.min(firstString.length(), secondString.length());
        int biggerStringLength = Math.max(firstString.length(), secondString.length());
        for (int index = 0; index < biggerStringLength; index++) {
            if (index >= smallerStringLength ) {
                if (isFirstStringBigger) {
                    sum += firstString.charAt(index);
                } else {
                    sum += secondString.charAt(index);
                }
            } else {
                sum += firstString.charAt(index) * secondString.charAt(index);
            }
        }

        return sum;
    }
}