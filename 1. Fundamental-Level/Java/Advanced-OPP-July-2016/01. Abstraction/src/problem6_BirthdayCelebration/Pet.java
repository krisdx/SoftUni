package problem6_BirthdayCelebration;

import problem6_BirthdayCelebration.constracts.Birthable;

public class Pet implements Birthable {
    private String birthdate;
    private String name;

    public Pet(String name, String birthdate) {
        this.birthdate = birthdate;
        this.name = name;
    }

    @Override
    public String getBithDate() {
        return this.birthdate;
    }
}