package Advanced_CSharp_Exam_31_May_2015;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem4_OlympicsAreComing {
    public static void main(String[] args) { // _!_
        Scanner input = new Scanner(System.in);

        LinkedHashMap<String, LinkedHashMap<String, Integer>> olympicLog = new LinkedHashMap<>();

        while (true) {
            String line = input.nextLine().trim();
            if (line.equals("report")) {
                break;
            }

            String[] inputDetails = line.split("\\|");
            String athlete = inputDetails[0].replaceAll("\\s+", " ").trim();
            String country = inputDetails[1].replaceAll("\\s+", " ").trim();

            if (!olympicLog.containsKey(country)) {
                olympicLog.put(country, new LinkedHashMap<>());
            }

            if (!olympicLog.get(country).containsKey(athlete)) {
                olympicLog.get(country).put(athlete, 0);
            }

            olympicLog.get(country).put(athlete, olympicLog.get(country).get(athlete) + 1);
        }

        for (Map.Entry<String, LinkedHashMap<String, Integer>> country : olympicLog.entrySet()) {

            int sum = 0;
            for (Map.Entry<String, Integer> athlete : country.getValue().entrySet()) {
                sum += athlete.getValue();
            }

            country.getValue().entrySet()
                    .stream()
                    .sorted((x, y) -> x.getValue().compareTo(y.getValue()))
                    .forEach(c -> System.out.printf("%s (%d participants): ", country.getKey(), country.getValue().size()));
            System.out.printf("%d wins\n", sum);
        }
    }
}