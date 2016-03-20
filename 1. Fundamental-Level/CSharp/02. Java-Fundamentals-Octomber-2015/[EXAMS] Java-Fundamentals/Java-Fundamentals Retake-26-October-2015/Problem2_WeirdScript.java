import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem2_WeirdScript {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        char[] letters = new char[]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        int n = Integer.parseInt(input.nextLine());
        char ch = letters[(n - 1) % letters.length];

        StringBuilder inputText = new StringBuilder();
        while (true) {
            String inputLine = input.nextLine();
            if (inputLine.equals("End")) {
                break;
            }

            inputText.append(inputLine);
        }

        System.out.println(inputText);

        String key = ch + "" + ch;
        Pattern pattern = Pattern.compile(String.format("%s(.{1,50}?)%s", key, key));
        Matcher matcher = pattern.matcher(inputText);

        StringBuilder output = new StringBuilder() ;
        while (matcher.find()) {
            output.append(matcher.group(1) + '\n');
        }

        System.out.println(output);
    }
}