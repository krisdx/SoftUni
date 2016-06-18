package setsAndMaps;

import java.util.*;

public class Problem8_HandsOfCards {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Map<String, Set<String>> map = new LinkedHashMap<>();
        while (true) {
            String inputLine = input.nextLine();
            if (inputLine.equals("JOKER")) {
                break;
            }

            String name = inputLine.split(":")[0];
            if (!map.containsKey(name)) {
                map.put(name, new HashSet<>());
            }

            int indexToSubstring = inputLine.indexOf(':');
            String[] cards = inputLine.substring(indexToSubstring + 2).split("[\\s+,]+");
            for (int i = 0; i < cards.length; i++) {
                String currentCard = cards[i];
                if (!map.get(name).contains(currentCard)) {
                    map.get(name).add(currentCard);
                }
            }
        }

        for (Map.Entry<String, Set<String>> entry : map.entrySet()) {
            System.out.print(entry.getKey() + ": ");
            long sum = 0;
            for (String card : map.get(entry.getKey())) {
                int power = 0;
                int type = 0;
                if (card.length() == 3) {
                    power = getPower(card.charAt(0) + "" + card.charAt(1));
                    type = getType(card.charAt(2));
                } else {
                    power = getPower(card.charAt(0) + "");
                    type = getType(card.charAt(1));
                }

                sum += (power * type);
            }
            System.out.println(sum);
        }
    }

    private static int getType(char type) {
        if (type == 'S') {
            return 4;
        } else if (type == 'H') {
            return 3;
        } else if (type == 'D') {
            return 2;
        } else {
            return 1;
        }
    }

    private static int getPower(String power) {
        if (power.equals("J")) {
            return 11;
        } else if (power.equals("Q")) {
            return 12;
        } else if (power.equals("K")) {
            return 13;
        } else if (power.equals("A")) {
            return 14;
        } else {
            return Integer.parseInt(power);
        }
    }
}