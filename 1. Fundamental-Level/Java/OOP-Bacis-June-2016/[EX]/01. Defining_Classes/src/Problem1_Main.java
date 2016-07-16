import java.lang.reflect.Field;

public class Problem1_Main {
    public static void main(String[] args) throws ClassNotFoundException {
        Class person = Class.forName("problem1_ClassPerson.Person");
        Field[] fields = person.getDeclaredFields();
        System.out.println(fields.length);

        Person gosho = new Person() {{
            setName("Gosho");
            setAge(15);
        }};

        Person pesho = new Person();
        pesho.setName("Pesho");
        pesho.setAge(61);

        Person stamat = new Person("Stamat", 30);
    }
}

 class Person {
    private String name;
    private int age;

    public Person() {

    }

    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return this.age;
    }

    public void setAge(int age) {
        this.age = age;
    }
}