package problem2_WildFarm.animals;

import problem2_WildFarm.foods.Food;
import problem2_WildFarm.foods.Vegetable;

public class Tiger extends Felime{

    public Tiger(String name, double weight, String livingRegion) {
        super(name, weight, livingRegion);
    }

    @Override
    public void eat(Food food) {
        if (food instanceof Vegetable){
            throw new IllegalArgumentException("Tigers are not eating that type of food!");
        }
        this.foodEaten += food.getQuantity();
    }

    @Override
    public String makeSound() {
        return "ROAAR!!!";
    }
}
