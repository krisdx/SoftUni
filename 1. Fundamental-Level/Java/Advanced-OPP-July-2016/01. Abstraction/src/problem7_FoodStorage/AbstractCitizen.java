package problem7_FoodStorage;

public abstract class AbstractCitizen implements Buyer {
    private  String name;
    private  int age;

    public AbstractCitizen(String name, int age) {
        this.name = name;
        this.age = age;
    }
}
