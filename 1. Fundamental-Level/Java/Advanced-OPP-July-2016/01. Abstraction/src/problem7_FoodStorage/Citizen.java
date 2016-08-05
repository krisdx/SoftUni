package problem7_FoodStorage;

public class Citizen extends AbstractCitizen {
    private String id;
    private String birthdate;

    public Citizen(String name, int age, String id, String birthdate) {
        super(name, age);
        this.id = id;
        this.birthdate = birthdate;
    }

    @Override
    public int buyFood() {
        return 10;
    }
}
