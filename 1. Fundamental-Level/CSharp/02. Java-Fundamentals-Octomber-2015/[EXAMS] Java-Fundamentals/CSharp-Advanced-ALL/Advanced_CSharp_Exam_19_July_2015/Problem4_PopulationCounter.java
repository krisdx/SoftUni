package Advanced_CSharp_Exam_19_July_2015;

import java.util.Collection;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem4_PopulationCounter {
    public static void main(String[] args) { // _!_
        Scanner input = new Scanner(System.in);

        Pattern pattern = Pattern.compile("(.+)\\|(.+)\\|(\\d+)");

        LinkedHashMap<String, LinkedHashMap<String, Long>> olympicsLog = new LinkedHashMap<>();
        while (true) {
            String line = input.nextLine();
            if (line.equals("report")) {
                break;
            }

            Matcher matcher = pattern.matcher(line);
            while (matcher.find()) {
                String city = matcher.group(1);
                String country = matcher.group(2);
                int population = Integer.parseInt(matcher.group(3));

                if (!olympicsLog.containsKey(country)) {
                    olympicsLog.put(country, new LinkedHashMap<>());
                }
                if (!olympicsLog.get(country).containsKey(city)) {
                    olympicsLog.get(country).put(city, 0L);
                }

                olympicsLog.get(country).put(city, olympicsLog.get(country).get(city) + population);
            }
        }

        for (Map.Entry<String, LinkedHashMap<String, Long>> country : olympicsLog.entrySet()) {
            long currentTotalPopulation = 0;
            for (Long currentPopulation : country.getValue().values()) {
                currentTotalPopulation += currentPopulation;
            }

            /*olympicsLog.keySet().stream()
                    .sorted((country1, country2) -> country1*/
                            // System.out.printf("%s (total population: %s)\n", country.getKey(), currentTotalPopulation);

                            country.getValue().entrySet().stream()
                                    .sorted((city1, city2) -> city2.getValue().compareTo(city1.getValue()))
                                    .forEach(city -> System.out.printf("=>%s: %d\n", city.getKey(), city.getValue()));
        }
    }
}