package problem5_PizzaCalories;

import problem5_PizzaCalories.models.*;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    private static BufferedReader reader;

    public static void main(String[] args) throws IOException {
        reader = new BufferedReader(new InputStreamReader(System.in));
        try{
            while (true) {
                String[] params = reader.readLine().split("\\s+");
                if (params[0].equals("END")) {
                    break;
                }
                String type = params[0];

                switch (type) {
                    case "Dough":
                        Dough dough = tryMakeDough(params);
                        System.out.println(String.format("%.2f", dough.calculateCalories()));
                        break;

                    case "Topping":
                        Topping topping = tryMakeTopping(params);
                        System.out.println(String.format("%.2f", topping.calculateCalories()));
                        break;


                    case "Pizza":
                        Pizza pizza = tryMakePizza(params);
                        System.out.println(pizza);
                        break;
                }
            }
        } catch (IllegalArgumentException ex){
            System.out.println(ex.getMessage());
        }
    }

    private static Pizza tryMakePizza(String[] params) throws IOException {
        String name = params[1];
        int toppingsCount = Integer.valueOf(params[2]);
        if (toppingsCount > 10) {
            throw new IllegalArgumentException("Number of toppings should be in range [0..10].");
        }
        Pizza pizza = new Pizza(name);

        String[] doughParams = reader.readLine().split("\\s+");
        Dough dough = tryMakeDough(doughParams);
        pizza.setDough(dough);

        for (int i = 0; i < toppingsCount; i++) {
            String[] toppingParams = reader.readLine().split("\\s+");
            Topping topping = tryMakeTopping(toppingParams);
            pizza.tryAddTopping(topping);
        }

        return pizza;
    }

    private static Topping tryMakeTopping(String[] params) {
        String type = params[1];
        double weight = Double.valueOf(params[2]);

        return new Topping(type, weight);
    }

    private static Dough tryMakeDough(String[] params) {
        String flourType = params[1];
        String bakingTechnique = params[2];
        double weight = Double.valueOf(params[3]);

        return new Dough(flourType, bakingTechnique, weight);
    }
}
