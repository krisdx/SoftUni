import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Problem4_NumberInReversedOrder {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        String n = reader.readLine();
        DecimalNumber decimalNumber = new DecimalNumber(n);
        System.out.println(decimalNumber.reverseNumber());
    }
}

class DecimalNumber {
    private String number;

    public DecimalNumber(String number) {
        this.number = number;
    }

    public String reverseNumber() {
        StringBuilder result = new StringBuilder();
        String[] a = this.number.split("\\.");
        if (a.length == 1) {
            result.append(this.reverseString(a[0]));
        } else {
            result.append(this.reverseString(a[1]));
            result.append(".");
            result.append(this.reverseString(a[0]));
        }

        return result.toString();
    }

    private String reverseString(String num) {
        StringBuilder result = new StringBuilder();
        for (int i = num.length() - 1; i >= 0; i--) {
            result.append(num.charAt(i));
        }

        return result.toString();
    }
}