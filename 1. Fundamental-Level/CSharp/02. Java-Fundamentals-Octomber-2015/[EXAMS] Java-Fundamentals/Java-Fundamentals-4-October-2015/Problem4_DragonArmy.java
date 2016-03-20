import java.util.*;

public class Problem4_DragonArmy {

    private static final int DEFAULT_DRAGON_HEALTH = 250;
    private static final int DEFAULT_DRAGON_DAMAGE = 45;
    private static final int DEFAULT_DRAGON_ARMOR = 10;

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        LinkedHashMap<String, TreeMap<String, Integer[]>> dragonLog = new LinkedHashMap<>();

        int n = Integer.parseInt(input.nextLine());
        for (int i = 0; i < n; i++) {
            String[] inputDetails = input.nextLine().split("\\s+");

            String dragonType = inputDetails[0];
            String dragonName = inputDetails[1];
            int damage = GetDamage(inputDetails[2]);
            int health = GetHealth(inputDetails[3]);
            int armor = GetArmor(inputDetails[4]);
            Integer[] stats = new Integer[]{damage, health, armor};

            if (!dragonLog.containsKey(dragonType)) {
                dragonLog.put(dragonType, new TreeMap<>());
            }

            dragonLog.get(dragonType).put(dragonName, stats);
        }

        for (Map.Entry<String, TreeMap<String, Integer[]>> dragonType : dragonLog.entrySet()) {
            System.out.print(dragonType.getKey() + "::(");
            double averageDamage = 0.0;
            double averageHealth = 0.0;
            double averageArmor = 0.0;

            int length = 0;
            for (Map.Entry<String, Integer[]> dragon : dragonType.getValue().entrySet()){
                averageDamage += dragon.getValue()[0];
                averageHealth += dragon.getValue()[1];
                averageArmor += dragon.getValue()[2];
                length++;
            }
            System.out.printf("%.2f/%.2f/%.2f)\n", averageDamage / length, averageHealth / length, averageArmor / length);

            for (Map.Entry<String, Integer[]> dragon : dragonType.getValue().entrySet()){
                System.out.printf("-%s -> damage: %d, health: %d, armor: %d\n", dragon.getKey(), dragon.getValue()[0], dragon.getValue()[1], dragon.getValue()[2]);
            }
        }
    }

    private static int GetArmor(String input) {
        if (input.equals("null")) {
            return DEFAULT_DRAGON_ARMOR;
        }

        return Integer.parseInt(input);
    }

    private static int GetHealth(String input) {
        if (input.equals("null")) {
            return DEFAULT_DRAGON_HEALTH;
        }

        return Integer.parseInt(input);
    }

    private static int GetDamage(String input) {
        if (input.equals("null")) {
            return DEFAULT_DRAGON_DAMAGE;
        }

        return Integer.parseInt(input);
    }
}