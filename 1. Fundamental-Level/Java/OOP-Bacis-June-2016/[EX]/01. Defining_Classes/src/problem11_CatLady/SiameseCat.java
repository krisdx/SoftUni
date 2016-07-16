package problem11_CatLady;

public class SiameseCat extends Cat{
    private String earSize;

    public SiameseCat(String name, String earSize) {
        super(name);
        this.earSize = earSize;
    }

    @Override
    public String toString() {
        return "Siamese " + super.toString() + " " + this.earSize;
    }
}