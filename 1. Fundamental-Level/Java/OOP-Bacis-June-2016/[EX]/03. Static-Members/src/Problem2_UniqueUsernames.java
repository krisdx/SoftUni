import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashSet;
import java.util.Set;

public class Problem2_UniqueUsernames {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Set<String> uniqueNames = new HashSet<>();

        while (true) {
            String name = reader.readLine();
            if (name.equals("End")) {
                break;
            }

            Person person = new Person(name);
            uniqueNames.add(name);
        }

        System.out.println(uniqueNames.size());
    }
}

class Person {
    public static int numberOfInstances;

    private String name;

    public Person(String name) {
        this.name = name;
        numberOfInstances++;
    }
}