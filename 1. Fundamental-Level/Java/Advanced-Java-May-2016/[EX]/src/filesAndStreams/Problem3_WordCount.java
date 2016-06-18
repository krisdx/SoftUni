package filesAndStreams;

import java.io.*;
import java.util.*;

public class Problem3_WordCount {
    public static void main(String[] args) throws IOException {
        String inputTextPath = System.getProperty("user.dir") +
                "\\resources\\03. WordCount\\text1.txt";
        String wordToFindPath = System.getProperty("user.dir") +
                "\\resources\\03. WordCount\\words1.txt";
        String outputTextPath = System.getProperty("user.dir") +
                "\\resources\\03. WordCount\\01_WordCountOut.txt";
        try (
                BufferedReader textReader = new BufferedReader(
                        new FileReader(inputTextPath));
                BufferedReader searchWordReader = new BufferedReader(
                        new FileReader(wordToFindPath));
                BufferedWriter writer = new BufferedWriter(
                        new FileWriter(outputTextPath))
        ) {
            Map<String, Integer> wordsCount = readWordFile(searchWordReader);
            readTextFile(textReader, wordsCount);
            writeWords(writer, wordsCount);
        }
    }

    private static void writeWords(BufferedWriter writer, Map<String, Integer> wordsCount) {
        wordsCount.entrySet()
                .stream()
                .sorted((w1, w2) -> w2.getValue().compareTo(w1.getValue()))
                .forEach(w -> {
                    String wordCount = String.format("%s - %d%n", w.getKey(), w.getValue());
                    try {
                        writer.write(wordCount);
                    } catch (IOException ex) {
                        ex.printStackTrace();
                    }
                });
    }

    private static void readTextFile(BufferedReader textReader, Map<String, Integer> wordsCount) throws IOException {
        String line;
        while ((line = textReader.readLine()) != null) {
            String[] currentLineWords = line.toLowerCase().split("[\"\\s?!.,;&()'*@#$%+<>-]+");
            for (int i = 0; i < currentLineWords.length; i++) {
                String currentWord = currentLineWords[i];
                if (wordsCount.containsKey(currentWord)) {
                    int currentCount = wordsCount.get(currentWord);
                    wordsCount.put(currentWord, currentCount + 1);
                }
            }
        }
    }

    private static Map<String, Integer> readWordFile(BufferedReader searchWordReader) throws IOException {
        Map<String, Integer> wordsCount = new LinkedHashMap<>();

        String[] wordsToFind = searchWordReader.readLine().toLowerCase().split("\\s+");
        for (int i = 0; i < wordsToFind.length; i++) {
            wordsCount.put(wordsToFind[i].toLowerCase(), 0);
        }

        return wordsCount;
    }
}