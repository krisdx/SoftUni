package streamAPI;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Scanner;
import java.util.stream.Collectors;

public class Problem10_GroupByGroup {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<Person> personInfo = new ArrayList<>();
        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            String[] personArgs = line.split("\\s+");
            Person person = new Person(personArgs[0] + " " + personArgs[1], Integer.valueOf(personArgs[2]));
            personInfo.add(person);
        }

        Map<Integer, List<Person>> map = personInfo.stream()
                .collect(Collectors.groupingBy(person -> person.group));

        for (Map.Entry<Integer, List<Person>> person : map.entrySet()) {
            System.out.printf("%d - ", person.getKey());
            int count = 0;
            for (int i = 0; i < person.getValue().size(); i++) {
                if (count + 1 == person.getValue().size()) {
                    System.out.print(person.getValue().get(i));
                } else {

                    System.out.print(person.getValue().get(i) + ", ");
                }

                count++;
            }
            System.out.println();
        }
    }
}

class Person {
    public String name;
    public Integer group;

    public Person(String name, Integer group) {
        this.name = name;
        this.group = group;
    }

    @Override
    public String toString() {
        return this.name;
    }
}