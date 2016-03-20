import java.util.Scanner;

public class GhettoNumeralSystem {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String inputNum = input.next();

        StringBuilder output = new StringBuilder();
        for (int i = 0; i < inputNum.length(); i++) {
            String convertedValue = GetValue(inputNum.charAt(i));
            output.append(convertedValue);
        }

        System.out.println(output);
    }

    private static String GetValue(char ch) {
        switch (ch) {
            case '0':
                return "Gee";
            case '1':
                return "Bro";
            case '2':
                return "Zuz";
            case '3':
                return "Ma";
            case '4':
                return "Duh";
            case '5':
                return "Yo";
            case '6':
                return "Dis";
            case '7':
                return "Hood";
            case '8':
                return "Jam";
            case '9':
                return "Mack";
            default:
                return "";
        }
    }
}