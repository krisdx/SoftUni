package problem2_WildFarm;

import problem2_WildFarm.animals.*;
import problem2_WildFarm.foods.*;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.lang.reflect.Constructor;

public class Main {
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        while (true) {
            String[] animalParams = reader.readLine().split("\\s+");
            if (animalParams[0].equals("End")) {
                break;
            }
            String type = animalParams[0];
            String name = animalParams[1];
            double weight = Double.valueOf(animalParams[2]);
            String livingRegion = animalParams[3];

            String[] foodParams = reader.readLine().split("\\s+");
            String foodType = "com.company.wildFarm.foods." + foodParams[0];
            int quantity = Integer.valueOf(foodParams[1]);

            Class<?> clazz = Class.forName(foodType);
            Constructor<?> ctor = clazz.getConstructor(Integer.class);
            Food food = (Food) ctor.newInstance(quantity);
            Animal animal = null;
            switch (type) {
                case "Cat":
                    String breed = animalParams[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                    break;

                case "Mouse":
                    animal = new Mouse(name, weight, livingRegion);
                    break;

                case "Tiger":
                    animal = new Tiger(name, weight, livingRegion);
                    break;

                case "Zebra":
                    animal = new Zebra(name, weight, livingRegion);
                    break;
            }
            if (animal != null) {
                System.out.println(animal.makeSound());
                try {
                    animal.eat(food);
                } catch (IllegalArgumentException ex) {
                    System.out.println(ex.getMessage());
                }
                System.out.println(animal);
            }
        }
    }
}
