package setsAndMaps;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem13_SrubskoUnleashed {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Map<String, VenueInfo> venues = new LinkedHashMap<>();
        Pattern pattern = Pattern.compile("([a-zA-Z\\s]+?)\\s@(.+?)\\s(\\d+)\\s(\\d+)");


        while (true) {
            String inputLine = input.nextLine();
            if (inputLine.equals("End")) {
                break;
            }

            Matcher matcher = pattern.matcher(inputLine);
            if (matcher.find()) {
                String singer = matcher.group(1);
                String venue = matcher.group(2);
                Long ticketPrice = Long.valueOf(matcher.group(3));
                Long ticketCount = Long.valueOf(matcher.group(4));
                Long totalMoney = ticketCount * ticketPrice;

                VenueInfo venueInfo = new VenueInfo(singer, totalMoney);
                if (!venues.containsKey(venue)) {
                    venues.put(venue, venueInfo);
                } else {
                    VenueInfo newVenueInfo = venues.get(venue);
                    if (!newVenueInfo.singers.containsKey(singer)) {
                        newVenueInfo.singers.put(singer, totalMoney);
                    } else {
                        Long currentMoney = newVenueInfo.singers.get(singer);
                        newVenueInfo.singers.put(singer, currentMoney + totalMoney);
                    }
                }
            }
        }

        for (Map.Entry<String, VenueInfo> venue : venues.entrySet()) {
            System.out.println(venue.getKey());
            venue.getValue().printSingers();
        }
    }
}

class VenueInfo {
    public VenueInfo(String singer, Long totalMoney) {
        singers.put(singer, totalMoney);
    }

    Map<String, Long> singers = new LinkedHashMap<>();

    public void printSingers() {
        this.singers
                .entrySet()
                .stream()
                .sorted((x, y) -> y.getValue().compareTo(x.getValue()))
                .forEach(x -> System.out.printf("#  %s -> %s\n", x.getKey(), x.getValue()));
    }
}