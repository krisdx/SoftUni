package ExamPractice_13June;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem3_JediCodeX {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int n = Integer.valueOf(reader.readLine());
        StringBuilder input = new StringBuilder();
        for (int i = 0; i < n; i++) {
            input.append(reader.readLine());
        }
        //System.out.println(input);

        String inputPattern1 = reader.readLine();
        String inputPattern2 = reader.readLine();

        String firstRegex = inputPattern1 + String.format("([a-zA-Z]{%d}(?![a-zA-Z]))", inputPattern1.length());
        Pattern firstPattern = Pattern.compile(firstRegex);
        List<String> names = new ArrayList<>();
        Matcher namesMatcher = firstPattern.matcher(input);
        while (namesMatcher.find()) {
            names.add(namesMatcher.group(1));
        }

        String secondRegex = inputPattern2 + String.format("([a-zA-Z0-9]{%d}(?![a-zA-Z0-9]))", inputPattern2.length());
        Pattern secondPattern = Pattern.compile(secondRegex);
        List<String> messages = new ArrayList<>();
        Matcher messagesMatcher = secondPattern.matcher(input);
        while (messagesMatcher.find()) {
            messages.add(messagesMatcher.group(1));
        }

        Integer[] messagesIndexes = Arrays.stream(reader.readLine()
                .split("\\s+")).map(Integer::valueOf)
                .toArray(Integer[]::new);
        int jediIndex = 0;
        for (int i = 0; i < messagesIndexes.length; i++) {
            if (messagesIndexes[i] - 1 >= 0 && messagesIndexes[i] - 1 < messages.size()) {
                System.out.printf("%s - %s%n", names.get(jediIndex), messages.get(messagesIndexes[i] - 1));
            }

            jediIndex++;
            if (jediIndex >= names.size()) {
                break;
            }
        }
    }
}