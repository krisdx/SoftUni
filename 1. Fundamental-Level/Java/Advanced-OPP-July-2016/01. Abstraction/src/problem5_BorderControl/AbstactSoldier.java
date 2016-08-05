package problem5_BorderControl;

public class AbstactSoldier implements Soldier {
    private String id;

    public AbstactSoldier(String id) {
        this.id = id;
    }

    @Override
    public String getId() {
        return this.id;
    }
}