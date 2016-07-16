package problem1_MethodSaysHello;

public class Person {
    private String name;

    public Person(String name) {
        this.name = name;
    }

    public void sayHello(){
        System.out.printf("%s says \"Hello\"!%n", this.name);
    }
}