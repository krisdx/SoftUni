package setsAndMaps;

import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Problem4_CountSymbols {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Map<Character, Integer> map = new TreeMap<>();
        String symbols = input.nextLine();
        for (int i = 0; i < symbols.length(); i++) {
            char symbol = symbols.charAt(i);
            if (!map.containsKey(symbol)) {
                map.put(symbol, 0);
            }

            int count = map.get(symbol);
            map.put(symbol, count + 1);
        }

        for (Map.Entry<Character, Integer> entry : map.entrySet()) {
            System.out.printf("%s: %d time/s", entry.getKey(), entry.getValue());
            System.out.println();
        }
    }
}