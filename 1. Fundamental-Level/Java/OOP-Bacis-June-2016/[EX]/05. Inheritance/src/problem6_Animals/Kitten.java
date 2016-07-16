package problem6_Animals;

public class Kitten extends Cat {
    private static final String KITTEN_GENDER = "Female";

    public Kitten(String name, int age) {
        super(name, age, KITTEN_GENDER);
    }

    @Override
    public void produceSound() {
        System.out.println("Miau");
    }
}