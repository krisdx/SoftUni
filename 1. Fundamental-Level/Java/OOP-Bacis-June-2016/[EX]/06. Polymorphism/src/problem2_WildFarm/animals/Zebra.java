package problem2_WildFarm.animals;

import problem2_WildFarm.foods.Food;
import problem2_WildFarm.foods.Meat;

public class Zebra extends Mammal {
    public Zebra(String name, double weight, String livingRegion) {
        super(name, weight, livingRegion);
    }

    @Override
    public void eat(Food food) {
        if (food instanceof Meat){
            throw new IllegalArgumentException("Zebras are not eating that type of food!");
        }

        this.foodEaten += food.getQuantity();
    }

    @Override
    public String makeSound() {
        return "Zs";
    }
}
