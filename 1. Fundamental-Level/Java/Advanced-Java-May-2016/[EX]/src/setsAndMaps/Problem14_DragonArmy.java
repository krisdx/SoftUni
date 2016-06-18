package setsAndMaps;

import java.util.*;

public class Problem14_DragonArmy {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Map<String, DragonCollection> dragonLog = new LinkedHashMap<>();

        int n = Integer.valueOf(input.nextLine());
        for (int i = 0; i < n; i++) {
            String[] dragonInfo = input.nextLine().split(" ");
            String type = dragonInfo[0];
            String name = dragonInfo[1];

            Dragon dragon = new Dragon(name, dragonInfo[3], dragonInfo[2], dragonInfo[4]);
            DragonCollection dragonCollection = new DragonCollection(dragon);
            if (!dragonLog.containsKey(type)) {
                dragonLog.put(type, dragonCollection);
            } else {
                DragonCollection newCollection = dragonLog.get(type);
                newCollection.dragons.put(name, dragon);
            }
        }

        for (Map.Entry<String, DragonCollection> type : dragonLog.entrySet()) {
            System.out.print(type.getKey() + "::");
            type.getValue().printAverageStats();
            type.getValue().printDragons();
        }
    }
}

class DragonCollection {
    Map<String, Dragon> dragons = new TreeMap<>();

    public DragonCollection(Dragon firstDragon) {
        this.dragons.put(firstDragon.name, firstDragon);
    }

    public void printDragons() {
        for (Map.Entry<String, Dragon> dragon : dragons.entrySet()) {
            System.out.println(dragon.getValue());
        }
    }

    public void printAverageStats() {
        Double averageHealth = 0.0;
        Double averageArmor = 0.0;
        Double averageDamage = 0.0;
        for (Map.Entry<String, Dragon> dragon : dragons.entrySet()) {
            averageHealth += dragon.getValue().health;
            averageDamage += dragon.getValue().damage;
            averageArmor += dragon.getValue().armor;
        }

        averageArmor /= dragons.size();
        averageDamage /= dragons.size();
        averageHealth /= dragons.size();

        System.out.printf("(%.2f/%.2f/%.2f)\n",
                averageDamage, averageHealth, averageArmor);
    }
}

class Dragon implements Comparable<Dragon> {
    private final int DEFAULT_HEALTH = 250;
    private final int DEFAULT_DAMAGE = 45;
    private final int DEFAULT_ARMOR = 10;

    public String name;
    public int health;
    public int damage;
    public int armor;

    public Dragon(String name, String health, String damage, String armor) {
        this.name = name;
        this.health = this.getHealth(health);
        this.damage = this.getDamage(damage);
        this.armor = this.getArmor(armor);
    }

    private int getArmor(String armor) {
        if (armor.equals("null")) {
            return DEFAULT_ARMOR;
        }

        return Integer.valueOf(armor);
    }

    private int getHealth(String health) {
        if (health.equals("null")) {
            return DEFAULT_HEALTH;
        }

        return Integer.valueOf(health);
    }

    private int getDamage(String damage) {
        if (damage.equals("null")) {
            return DEFAULT_DAMAGE;
        }

        return Integer.valueOf(damage);
    }

    @Override
    public String toString() {
        return String.format("-%s -> damage: %s, health: %s, armor: %s",
                this.name, this.damage, this.health, this.armor);
    }

    @Override
    public int compareTo(Dragon other) {
        return this.name.compareTo(other.name);
    }
}