import java.util.Scanner;
import java.util.Map;
import java.util.LinkedHashMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem12_CardsFrequencies {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Pattern pattern = Pattern.compile("[0-9JQKA]+");
        Matcher matcher = pattern.matcher(input.nextLine());

        LinkedHashMap<String, Integer> dictionary = new LinkedHashMap<>();
        double length = 0.0;
        while (matcher.find()) {
            length++;
            String currentCardFace = matcher.group();

            if (!dictionary.containsKey(currentCardFace)) {
                dictionary.put(currentCardFace, 1);
                continue;
            }

            dictionary.put(currentCardFace, dictionary.get(currentCardFace) + 1);
        }

        for (Map.Entry<String, Integer> cardFace : dictionary.entrySet()) {
            System.out.printf("%s -> %.2f%%\n", cardFace.getKey(), (cardFace.getValue() / length) * 100);
        }
    }
}