package problem5_BorderControl;

public class Robot extends AbstactSoldier {
    private String model;

    public Robot(String id, String model) {
        super(id);
        this.model = model;
    }
}