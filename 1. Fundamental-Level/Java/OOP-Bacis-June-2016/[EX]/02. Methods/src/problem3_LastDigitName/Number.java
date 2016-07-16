package problem3_LastDigitName;

public class Number {
    private int value;

    public Number(int value) {
        this.value = value;
    }

    @Override
    public String toString() {
        String lastDigitToString = this.getLastDigitToString();
        return lastDigitToString;
    }

    private String getLastDigitToString() {
        int lastDigit = this.value % 10;
        if (lastDigit == 0) {
            return "zero";
        } else if (lastDigit == 1) {
            return "one";
        } else if (lastDigit == 2) {
            return "two";
        } else if (lastDigit == 3) {
            return "three";
        } else if (lastDigit == 4) {
            return "four";
        } else if (lastDigit == 5) {
            return "five";
        } else if (lastDigit == 6) {
            return "six";
        } else if (lastDigit == 7) {
            return "seven";
        } else if (lastDigit == 8) {
            return "eight";
        } else if (lastDigit == 9) {
            return "nine";
        }

        return "Not a digig";
    }
}