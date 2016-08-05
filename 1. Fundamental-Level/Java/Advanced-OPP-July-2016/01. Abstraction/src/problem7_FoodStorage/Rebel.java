package problem7_FoodStorage;

public class Rebel extends AbstractCitizen {
    private String name;
    private int age;
    private String group;

    public Rebel(String name, int age, String group) {
        super(name, age);
        this.group = group;
    }

    @Override
    public int buyFood() {
        return 5;
    }
}
