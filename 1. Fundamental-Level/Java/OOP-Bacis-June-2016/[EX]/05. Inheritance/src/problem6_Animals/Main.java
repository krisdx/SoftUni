package problem6_Animals;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        List<Animal> animals = new ArrayList<>();
        while (true) {
            String line = reader.readLine().trim();
            if (line.equals("Beast!")) {
                break;
            }

            String[] lineArgs = reader.readLine().trim().split("\\s+");
            String type = line;
            try {
                Animal animal = null;

                try {
                    String name = lineArgs[0];
                    int age = Integer.valueOf(lineArgs[1]);
                    if (type.equals("Dog")) {
                        animal = new Dog(name, age, lineArgs[2]);
                    } else if (type.equals("Cat")) {
                        animal = new Cat(name, age, lineArgs[2]);
                    } else if (type.equals("Frog")) {
                        animal = new Frog(name, age, lineArgs[2]);
                    } else if (type.equals("Kitten")) {
                        animal = new Kitten(name, age);
                    } else if (type.equals("Tomcat")) {
                        animal = new Tomcat(name, age);
                    }else {
                        continue;
                    }
                } catch (NumberFormatException ex) {
                    System.out.println("Invalid input!");
                }

                animals.add(animal);
            } catch (IllegalArgumentException ex) {
                System.out.println(ex.getMessage());
                return;
            }
        }

        for (Animal animal : animals) {
            System.out.println(animal);
            animal.produceSound();
        }
    }
}