package problem11_CatLady;

public class StreetExtraordinaireCat extends Cat {
    private String decibelsOfMeows;

    public StreetExtraordinaireCat(String name, String decibelsOfMeows) {
        super(name);
        this.decibelsOfMeows = decibelsOfMeows;
    }

    @Override
    public String toString() {
        return "StreetExtraordinaire " + super.toString() + " " + this.decibelsOfMeows;
    }
}