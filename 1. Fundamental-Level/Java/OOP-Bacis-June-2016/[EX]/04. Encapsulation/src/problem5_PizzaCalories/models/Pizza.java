package problem5_PizzaCalories.models;

import java.util.ArrayList;
import java.util.List;

public class Pizza {
    private String name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(String name) {
        this.setName(name);
        this.dough = null;
        this.toppings = new ArrayList<>();
    }

    private void setName(String name) {
        if (name == null || name.trim().length() == 1 || name.trim().length() > 15){
            throw new IllegalArgumentException("Pizza name should be between 1 and 15 symbols.");
        }
        this.name = name;
    }

    public void setDough(Dough dough){
        this.dough = dough;
    }

    public void tryAddTopping(Topping topping){
        if (this.toppings.size() > 10){
            throw new IllegalArgumentException("Number of toppings should be in range [0..10].");
        }

        this.toppings.add(topping);
    }

    public int getNumberOfTopping(){
        return this.toppings.size();
    }

    public double getTotalCalories(){
        double totalCalories = this.dough.calculateCalories();
        for (Topping topping : toppings) {
            totalCalories += topping.calculateCalories();
        }

        return totalCalories;
    }

    @Override
    public String toString() {
        return String.format("%s - %.2f Calories.", this.name, this.getTotalCalories());
    }
}
