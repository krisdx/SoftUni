package problem2_WildFarm.animals;

import problem2_WildFarm.foods.Food;

import java.text.DecimalFormat;

public class Cat extends Felime {
    private String breed;

    public Cat(String name, double weight, String livingRegion, String breed) {
        super(name, weight, livingRegion);
        this.breed = breed;
    }

    @Override
    public String toString() {
        DecimalFormat df = new DecimalFormat("0.######");
        return String.format("%s[%s, %s, %s, %s, %s]",
                this.getClass().getSimpleName(),
                this.name,
                this.breed,
                df.format(this.weight),
                this.livingRegion,
                this.foodEaten);
    }

    @Override
    public void eat(Food food) {
        this.foodEaten += food.getQuantity();
    }

    @Override
    public String makeSound() {
        return "Meowwww";
    }
}
