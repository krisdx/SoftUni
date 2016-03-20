import java.util.Scanner;
import java.util.Map;
import java.util.TreeMap;

public class Problem11_MostFrequentWord {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] words = input.nextLine().toLowerCase().split("\\W+");

        TreeMap<String, Integer> wordsAndFrequenciesDictionary = new TreeMap();
        int maxOccurrencesCount = 0;
        for (int i = 0; i < words.length; i++) {
            String currentWord = words[i];

            if (!wordsAndFrequenciesDictionary.containsKey(currentWord)){
                wordsAndFrequenciesDictionary.put(currentWord, 1);
                continue;
            }

            wordsAndFrequenciesDictionary.put(currentWord, wordsAndFrequenciesDictionary.get(currentWord) + 1);
            if (wordsAndFrequenciesDictionary.get(currentWord) > maxOccurrencesCount){
                maxOccurrencesCount = wordsAndFrequenciesDictionary.get(currentWord);
            }
        }

        for (Map.Entry<String, Integer> pair : wordsAndFrequenciesDictionary.entrySet()) {
            if (pair.getValue() == maxOccurrencesCount){
                System.out.printf("%s -> %s times\n", pair.getKey(), pair.getValue());
            }
        }
    }
}