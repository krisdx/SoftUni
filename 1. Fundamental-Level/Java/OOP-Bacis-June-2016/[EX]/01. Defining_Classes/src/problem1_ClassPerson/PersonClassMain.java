import java.lang.reflect.Field;

public class PersonClassMain {
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
