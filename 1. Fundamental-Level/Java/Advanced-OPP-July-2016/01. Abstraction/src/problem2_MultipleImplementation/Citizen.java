package problem2_MultipleImplementation;

public class Citizen implements Person, Identifiable, Birthable {

    private int age;
    private String name;
    private String id;
    private String birthDate;

    public Citizen(String name, int age, String id, String birthDate) {
        this.age = age;
        this.name = name;
        this.id = id;
        this.birthDate = birthDate;
    }

    @Override
    public String getBirthdate() {
        return this.birthDate;
    }

    @Override
    public String getId() {
        return this.id;
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public int getAge() {
        return this.age;
    }
}