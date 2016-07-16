package problem2_WildFarm.animals;

import problem2_WildFarm.foods.Food;
import problem2_WildFarm.foods.Meat;

public class Mouse extends Mammal{

    public Mouse(String name, double weight, String livingRegion) {
        super(name, weight, livingRegion);
    }

    @Override
    public void eat(Food food) {
        if (food instanceof Meat){
            throw new IllegalArgumentException("Mouses are not eating that type of food!");
        }
        if (food.getQuantity() <= 0){
            throw new IllegalArgumentException("A cheese was just eaten!");
        }

        this.foodEaten += food.getQuantity();
    }

    @Override
    public String makeSound() {
        return "SQUEEEAAAK!";
    }
}
