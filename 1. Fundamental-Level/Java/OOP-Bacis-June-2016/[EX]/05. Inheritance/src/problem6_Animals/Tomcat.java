package problem6_Animals;

public class Tomcat extends Cat {
    private static final String TOMCAT_GENDER = "Male";

    public Tomcat(String name, int age) {
        super(name, age, TOMCAT_GENDER);
    }

    @Override
    public void produceSound() {
        System.out.println("Give me one million b***h");
    }
}