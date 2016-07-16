package problem5_AnimalClinic;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Problem5_Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Map<String, List<Animal>> animals = new HashMap<>();
        animals.put("heal",new ArrayList<>());
        animals.put("rehabilitated", new ArrayList<>());

        while (true) {
            String line = reader.readLine();
            if (line.equals("End")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String name = lineArgs[0];
            String breed = lineArgs[1];
            Animal animal = new Animal(name, breed);
            if (lineArgs[2].equals("heal")) {
                System.out.printf("Patient %d: [%s (%s)] has been healed!%n", AnimalClinic.patientId, animal.getName(), animal.getBreed());
                animals.get("heal").add(animal);
                AnimalClinic.healedAnimalsCount++;
                AnimalClinic.patientId++;
            } else {
                System.out.printf("Patient %d: [%s (%s)] has been rehabilitated!%n", AnimalClinic.patientId, animal.getName(), animal.getBreed());
                AnimalClinic.rehabilitedAnimalsCount++;
                List<Animal> a= animals.get("rehabilitated");
                animals.get("rehabilitated").add(animal);
                AnimalClinic.patientId++;
            }
        }

        System.out.println("Total healed animals: " + AnimalClinic.healedAnimalsCount);
        System.out.println("Total rehabilitated animals: " + AnimalClinic.rehabilitedAnimalsCount);

        String command = reader.readLine();
        for (Animal animal : animals.get(command)) {
            System.out.println(animal);
        }
    }
}