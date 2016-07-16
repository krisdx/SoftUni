package problem2_CreatingConstructors;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.lang.reflect.Constructor;

public class CreatingConstructorsMain {
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Class personClass = Class.forName("problem2_CreatingConstructors.Person");
        Constructor emptyConstructor = personClass.getDeclaredConstructor();
        Constructor ageConstructor = personClass.getDeclaredConstructor(int.class);
        Constructor nameAndAgeConstructor = personClass.getDeclaredConstructor(String.class, int.class);

        String name = reader.readLine();
        int age = Integer.valueOf(reader.readLine());

        Person basePerson = (Person) emptyConstructor.newInstance();
        Person baseWithAge = (Person) ageConstructor.newInstance(age);
        Person baseWithNameAndAge = (Person) nameAndAgeConstructor.newInstance(name, age);

        System.out.printf("%s %s%n", basePerson.getName(), basePerson.getAge());
        System.out.printf("%s %s%n", baseWithAge.getName(), baseWithAge.getAge());
        System.out.printf("%s %s%n", baseWithNameAndAge.getName(), baseWithNameAndAge.getAge());
    }
}