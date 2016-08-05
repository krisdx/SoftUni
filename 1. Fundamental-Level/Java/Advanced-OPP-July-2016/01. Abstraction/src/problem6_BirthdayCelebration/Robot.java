package problem6_BirthdayCelebration;

import problem6_BirthdayCelebration.constracts.Identifiable;

public class Robot implements Identifiable {
    private String id;
    private String model;

    public Robot(String id, String model) {
        this.id = id;
        this.model = model;
    }

    @Override
    public String getId() {
        return this.id;
    }
}