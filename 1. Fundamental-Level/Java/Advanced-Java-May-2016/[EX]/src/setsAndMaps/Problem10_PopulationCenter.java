package setsAndMaps;

import java.util.LinkedHashMap;
import java.util.Map;

public class Problem10_PopulationCenter {
    public static void main(String[] args) {
        Map<Integer, Map<String, Integer>> map = new LinkedHashMap<>();
        map.put(1, new LinkedHashMap<>());
        map.get(1).put("Test", 15);
        map.get(1).put("vla", 5);
        map.put(2, new LinkedHashMap<>());
        map.get(2).put("Test", 0);
        map.get(2).put("Test2", 6);

        // TODO: moga v sorted da podam komparator
        /*map.entrySet().stream().sorted(Map.Entry.comparingByValue((x, y) -> y.)
                .forEach(e -> System.out.printf("%s -> %s\n", e.getKey(), e.getValue()));*/

        /*for (Map.Entry<Integer, Integer> entry : map.entrySet()) {
            System.out.printf("%s -> %s\n", entry.getKey(), entry.getValue());
        }*/
    }
}

class CountryInfo {

}