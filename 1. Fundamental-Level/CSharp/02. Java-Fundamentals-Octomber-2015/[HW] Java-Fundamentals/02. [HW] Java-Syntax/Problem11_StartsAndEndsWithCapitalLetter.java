import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem11_StartsAndEndsWithCapitalLetter {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String inputText = input.nextLine();

        Pattern pattern = Pattern.compile("\\b[A-Z][a-zA-Z]*[A-Z]\\b");
        Matcher matcher = pattern.matcher(inputText);

        while (matcher.find()){
            System.out.print(matcher.group() + " ");
        }
    }
}
