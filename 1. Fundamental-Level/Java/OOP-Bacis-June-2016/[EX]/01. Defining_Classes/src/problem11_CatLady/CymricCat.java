package problem11_CatLady;

public class CymricCat extends Cat {
    private String furLength;

    public CymricCat(String name, String furLength) {
        super(name);
        this.furLength = furLength;
    }

    @Override
    public String toString() {
        return "Cymric " + super.toString() + " " + this.furLength;
    }
}