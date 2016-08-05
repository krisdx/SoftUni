package problem6_BirthdayCelebration;

import problem6_BirthdayCelebration.constracts.Birthable;
import problem6_BirthdayCelebration.constracts.Identifiable;

public class Citizen implements  Identifiable, Birthable {
    private  String id;
    private String name;
    private int age;
    private String birthDate;

    public Citizen(String id, String name, int age, String bithDate) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.birthDate = bithDate;
    }

    @Override
    public String getBithDate() {
        return this.birthDate;
    }

    @Override
    public String getId() {
        return this.id;
    }
}