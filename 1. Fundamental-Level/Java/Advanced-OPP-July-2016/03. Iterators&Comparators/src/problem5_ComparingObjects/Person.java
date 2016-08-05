package problem5_ComparingObjects;

public class Person implements Comparable<Person> {

    private String name;
    private int age;
    private String town;

    public Person(String name, int age, String town) {
        this.name = name;
        this.age = age;
        this.town = town;
    }

    @Override
    public int compareTo(Person other) {
        int compareIndex = this.name.compareTo(other.name);
        if (compareIndex == 0) {
            compareIndex = Integer.compare(this.age, other.age);
            if (compareIndex == 0) {
                compareIndex = this.town.compareTo(other.town);
            }
        }

        return compareIndex;
    }

    @Override
    public String toString() {
        return String.format("%s %d %s",
                this.name, this.age, this.town);
    }
}
