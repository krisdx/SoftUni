import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.lang.reflect.Constructor;

public class Problem2_Main {
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Class personClass = Class.forName("problem2_CreatingConstructors.Person");
        Constructor emptyConstructor = personClass.getDeclaredConstructor();
        Constructor ageConstructor = personClass.getDeclaredConstructor(int.class);
        Constructor nameAndAgeConstructor = personClass.getDeclaredConstructor(String.class, int.class);

        String name = reader.readLine();
        int age = Integer.valueOf(reader.readLine());

        Person2 basePerson = (Person2) emptyConstructor.newInstance();
        Person2 baseWithAge = (Person2) ageConstructor.newInstance(age);
        Person2 baseWithNameAndAge = (Person2) nameAndAgeConstructor.newInstance(name, age);

        System.out.printf("%s %s%n", basePerson.getName(), basePerson.getAge());
        System.out.printf("%s %s%n", baseWithAge.getName(), baseWithAge.getAge());
        System.out.printf("%s %s%n", baseWithNameAndAge.getName(), baseWithNameAndAge.getAge());
    }
}


class Person2 {
    public String name;
    public int age;

    public Person2(String name, int age) {
        this.name = name;
        this.age = age;
    }

    public Person2() {
        this("No name", 1);
    }

    public Person2(int age) {
        this("No name", age);
    }

    public String getName() {
        return this.name;
    }

    public int getAge() {
        return this.age;
    }
}