package problem5_ComparingObjects;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        List<Person> people = new ArrayList<>();
        while (true) {
            String line = reader.readLine();
            if (line.equals("END")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String name = lineArgs[0];
            int age = Integer.valueOf(lineArgs[1]);
            String town = lineArgs[2];

            Person person = new Person(name, age, town);
            people.add(person);
        }

        int index = Integer.valueOf(reader.readLine()) - 1;
        int numberOfEqualPeople = 0;
        int numberOfNotEqualPeople = 0;
        for (int i = 0; i < people.size(); i++) {
            if (i == index) {
                continue;
            }

            boolean areEqual = people.get(i).compareTo(people.get(index)) == 0;
            if (areEqual) {
                numberOfEqualPeople++;
            } else {
                numberOfNotEqualPeople++;
            }
        }

        if (numberOfEqualPeople == 0) {
            System.out.println("No matches");
        } else {
            System.out.printf("%d %d %d%n",
                    numberOfEqualPeople + 1, numberOfNotEqualPeople, people.size());
        }
    }
}