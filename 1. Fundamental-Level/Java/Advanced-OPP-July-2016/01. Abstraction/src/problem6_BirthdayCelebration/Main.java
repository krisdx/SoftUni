package problem6_BirthdayCelebration;

import problem6_BirthdayCelebration.constracts.Birthable;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Map<String, List<Birthable>> citizensAndPets = new HashMap<>();

        while (true) {
            String line = scanner.nextLine();
            if (line.equals("End")) {
                break;
            }

            String[] lineArgs = line.split(" ");
            Birthable citizen = null;
            String type = lineArgs[0];
            if (type.equals("Citizen")) {
                String name = lineArgs[1];
                int age = Integer.valueOf(lineArgs[2]);
                String id = lineArgs[3];
                String birthdate = lineArgs[4];
                citizen = new Citizen(id, name, age, birthdate);

                add(citizensAndPets, citizen, birthdate);
            } else if (type.equals("Pet")) {
                String name = lineArgs[1];
                String birthdate = lineArgs[2];
                citizen = new Pet(name, birthdate);

                add(citizensAndPets, citizen, birthdate);
            }
        }

        String targetBirthdate = scanner.nextLine();
        for (Map.Entry<String, List<Birthable>> citizen : citizensAndPets.entrySet()) {
            if (citizen.getKey().split("/")[2].equals(targetBirthdate)) {
                for (Birthable birthable : citizen.getValue()) {
                    System.out.println(birthable.getBithDate());
                }
            }
        }
    }

    private static void add(
            Map<String, List<Birthable>> citizensAndPets,
            Birthable citizen,
            String birthdate) {
        if (!citizensAndPets.containsKey(birthdate)) {
            citizensAndPets.put(birthdate, new ArrayList<>());
        }

        citizensAndPets.get(birthdate).add(citizen);
    }
}