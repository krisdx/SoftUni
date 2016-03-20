package Advanced_CSharp_Exam_11_October_2015;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem4_SrubskoUnleashed {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        LinkedHashMap<String, LinkedHashMap<String, Long>> parties = new LinkedHashMap<>();

        Pattern pattern = Pattern.compile("(.+?)\\s@(.+?)\\s(\\d+)\\s(\\d+)");
        while (true) {
            String inputLine = input.nextLine();
            if (inputLine.equals("End")) {
                break;
            }

            Matcher matcher = pattern.matcher(inputLine);
            if (matcher.find()) {
                String singer = matcher.group(1).trim();
                String venue = matcher.group(2).trim();
                long ticketPrice = Integer.parseInt(matcher.group(3).trim());
                long ticketCount = Integer.parseInt(matcher.group(4).trim());

                if (!parties.containsKey(venue)) {
                    parties.put(venue, new LinkedHashMap<>());
                }
                if (!parties.get(venue).containsKey(singer)) {
                    parties.get(venue).put(singer, 0L);
                }

                parties.get(venue).put(singer, parties.get(venue).get(singer) + ticketCount * ticketPrice);
            }
        }

        for (Map.Entry<String, LinkedHashMap<String, Long>> venue : parties.entrySet()) {
            System.out.println(venue.getKey());
            venue.getValue().entrySet()
                    .stream()
                    .sorted((num1, num2) -> num2.getValue().compareTo(num1.getValue()))
                    .forEach(singer -> System.out.printf("#  %s -> %s\n", singer.getKey(), singer.getValue()));
        }
    }
}