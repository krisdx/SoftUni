package setsAndMaps;

import java.util.*;

public class Problem12_LegendaryFarming {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        TreeMap<String, Integer> junk = new TreeMap<>();

        int fragmentsCount = 0;
        int shardsCount = 0;
        int motesCount = 0;

        boolean itemFound = false;
        while (!itemFound) {
            String[] materials = input.nextLine().toLowerCase().split("\\s+");
            for (int i = 0; i < materials.length; i+=2) {
                String type = materials[i + 1];
                int amount = Integer.parseInt(materials[i]);

                if (type.equals("fragments")) {
                    fragmentsCount += amount;
                    if (fragmentsCount >= 250) {
                        System.out.println("Valanyr obtained!");
                        fragmentsCount -= 250;
                        itemFound = true;
                        break;
                    }
                } else if (type.equals("shards")) {
                    shardsCount += amount;
                    if (shardsCount >= 250) {
                        System.out.println("Shadowmourne obtained!");
                        shardsCount -= 250;
                        itemFound = true;
                        break;
                    }
                } else if (type.equals("motes")) {
                    motesCount += amount;
                    if (motesCount >= 250) {
                        System.out.println("Dragonwrath obtained!");
                        motesCount -= 250;
                        itemFound = true;
                        break;
                    }
                } else {
                    if (!junk.containsKey(type)) {
                        junk.put(type, 0);
                    }

                    junk.put(type, junk.get(type) + amount);
                }
            }
        }

        TreeMap<String, Integer> legends = new TreeMap<>();
        legends.put("fragments", fragmentsCount);
        legends.put("shards", shardsCount);
        legends.put("motes", motesCount);

        legends.entrySet().stream()
                .sorted((value1, value2) -> value2.getValue().compareTo(value1.getValue()))
                .forEach(legend -> System.out.printf("%s: %d\n", legend.getKey(), legend.getValue()));

        for (Map.Entry<String, Integer> j : junk.entrySet()) {
            System.out.printf("%s: %d\n", j.getKey(), j.getValue());
        }
    }
}