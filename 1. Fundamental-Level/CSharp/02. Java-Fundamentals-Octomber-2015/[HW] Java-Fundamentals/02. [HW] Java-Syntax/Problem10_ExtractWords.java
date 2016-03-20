import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem10_ExtractWords {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String inputText = input.nextLine();

        Pattern pattern = Pattern.compile("[a-zA-z]{2,}");
        Matcher matcher = pattern.matcher(inputText);

        while (matcher.find()){
            System.out.print(matcher.group() + " ");
        }
    }
}