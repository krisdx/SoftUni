package problem2_WildFarm.animals;

import problem2_WildFarm.interfaces.FoodEdible;
import problem2_WildFarm.interfaces.SoundProducible;

public abstract class Animal implements SoundProducible, FoodEdible {
    String name;
    double weight;
    int foodEaten;

    Animal(String name, double weight) {
        this.name = name;
        this.weight = weight;
        this.foodEaten = 0;
    }
}
