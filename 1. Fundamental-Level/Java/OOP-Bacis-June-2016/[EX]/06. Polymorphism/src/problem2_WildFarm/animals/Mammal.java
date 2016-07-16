package problem2_WildFarm.animals;

import java.text.DecimalFormat;

public abstract class Mammal extends Animal {
    String livingRegion;

    Mammal(String name, double weight, String livingRegion) {
        super(name, weight);
        this.livingRegion = livingRegion;
    }

    @Override
    public String toString() {
        DecimalFormat df = new DecimalFormat("0.######");
        return String.format("%s[%s, %s, %s, %s]",
                this.getClass().getSimpleName(),
                this.name,
                df.format(this.weight),
                this.livingRegion,
                this.foodEaten);
    }
}
