import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Problem12_PrintPeople {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        List<Person> people = new ArrayList<>();
        while (true) {
            String line = reader.readLine();
            if (line.equals("END")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String name = lineArgs[0];
            Integer age = Integer.valueOf(lineArgs[1]);
            String occupation = lineArgs[2];

            Person person = new Person(name, age, occupation);
            people.add(person);
        }

        people.stream().sorted().forEach(System.out::println);

    }
}

class Person implements Comparable<Person> {
    private String name;
    private Integer age;
    private String occupation;

    public Person(String name, int age, String occupation) {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
    }

    @Override
    public String toString() {
        return String.format("%s - age: %d, occupation: %s", this.name, this.age, this.occupation);
    }

    @Override
    public int compareTo(Person other) {
        return this.age.compareTo(other.age);
    }
}