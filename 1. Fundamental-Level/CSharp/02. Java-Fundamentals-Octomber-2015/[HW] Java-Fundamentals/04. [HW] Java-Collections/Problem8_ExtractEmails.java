import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem8_ExtractEmails {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String inputText = input.nextLine();
        Pattern pattern = Pattern.compile("([.\\-\\w]+)@([a-zA-Z.\\-]+[a-zA-Z])");
        Matcher matcher = pattern.matcher(inputText);

        while (matcher.find()){
            System.out.println(matcher.group());
        }
    }
}