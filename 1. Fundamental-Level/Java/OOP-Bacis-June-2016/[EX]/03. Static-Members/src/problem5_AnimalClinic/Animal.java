package problem5_AnimalClinic;

public class Animal {
    private String name;
    private String breed;

    public Animal(String name, String breed) {
        this.name = name;
        this.breed = breed;
    }

    public String getName() {
        return this.name;
    }

    public String getBreed() {
        return this.breed;
    }

    @Override
    public String toString() {
        return String.format("%s %s", this.name, this.breed);
    }
}