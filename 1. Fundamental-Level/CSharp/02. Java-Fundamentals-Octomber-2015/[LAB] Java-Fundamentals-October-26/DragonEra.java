import java.util.ArrayList;
import java.util.Scanner;

public class DragonEra {

    public static int dragonsCount = 0;

    public static void main(String[] args) { // not finished
        Scanner input = new Scanner(System.in);

        ArrayList<Dragon> dragons = new ArrayList<>();
        int initialDragonsCount = Integer.parseInt(input.nextLine());
        for (int i = 1; i <= initialDragonsCount; i++) {
            Dragon dragon = new Dragon("Dragon_" + i, 0);

            int numberOfEggs = Integer.parseInt(input.nextLine());
            for (int j = 0; j < numberOfEggs; j++) {
                Egg egg = new Egg(0, dragon);
                dragon.lay();
            }

            dragons.add(dragon);
        }

        dragonsCount = initialDragonsCount + 1;

        int numberOfYears = Integer.parseInt(input.nextLine());
        for (int i = 1; i <= numberOfYears; i++) {
            String yearType = input.nextLine();
            YearType yearFactor = YearType.valueOf(yearType);

            for (Dragon dragon : dragons) {
                passAge(dragon, yearFactor);
            }
        }

        print(dragons);
    }

    private static void print(ArrayList<Dragon> dragons) {
        for (Dragon dragon : dragons) {
            System.out.println(dragon);
            System.out.print("  ");

            if (dragon.getChildren() != null || dragon.getChildren().size() > 0) {
                for (Dragon child : dragon.getChildren()) {
                    print(dragon.getChildren());
                }
            }
        }
    }

    public static void passAge(Dragon dragon, YearType yearType) {
        dragon.age();
        dragon.lay();

        if (dragon.isAlive) {
            for (Egg egg : dragon.getEggs()) {
                egg.setYearType(yearType);

                egg.age();
                egg.hatch();
            }
        }

        for (Dragon child : dragon.getChildren()) {
            passAge(child, yearType);
        }

    }
}

class Dragon {
    private final int AGE_DEATH = 6;
    private final int AGE_LAY_EGGS_START = 3;
    private final int AGE_LAY_EGGS_END = 4;

    private String name;
    private int age;
    private ArrayList<Egg> eggs;
    public boolean isAlive;
    private ArrayList<Dragon> children;

    public Dragon(String name, int age) {
        this.name = name;
        this.age = age;
        this.eggs = new ArrayList<>();
        this.isAlive = true;
        this.children = new ArrayList<>();
    }

    public void lay() {
        if (this.age >= AGE_LAY_EGGS_START &&
                this.age <= AGE_LAY_EGGS_END) {
            Egg egg = new Egg(0, this);
            this.eggs.add(egg);
        }
    }

    public void age() {
        if (this.isAlive) {
            this.age++;
            if (age == AGE_DEATH) {
                this.isAlive = false;
            }
        }
    }

    public void increaseOffspring(Dragon babyDragon) {
        this.children.add(babyDragon);
    }

    public Iterable<Egg> getEggs() {
        return this.eggs;
    }

    public ArrayList<Dragon> getChildren() {
        return children;
    }

    public String getName() {
        return name;
    }

    public String toString(){
        return this.name;
    }
}

class Egg {
    private final int HATCH_AGE = 2;

    private int age;
    private Dragon parent;
    private YearType yearType;

    public void setYearType(YearType yearType) {
        this.yearType = yearType;
    }

    public Egg(int age, Dragon parent) {
        this.age = age;
        this.parent = parent;
    }

    public void age() {
        this.age++;
    }

    public void hatch() {
        if (this.age == HATCH_AGE) {
            int yearFactor = this.yearType.ordinal();
            for (int i = 0; i < yearFactor; i++) {
                Dragon babyDragon = new Dragon(this.parent.getName() + "/" + "Dragon_" + DragonEra.dragonsCount, 0);
                this.parent.increaseOffspring(babyDragon);
                DragonEra.dragonsCount++;
            }
        }
    }
}

enum YearType {
    Bad,
    Normal,
    Good
}