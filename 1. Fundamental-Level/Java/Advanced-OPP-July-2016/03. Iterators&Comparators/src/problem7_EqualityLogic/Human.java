package problem7_EqualityLogic;

public class Human implements Comparable<Human> {

    private String name;
    private Integer age;

    public Human(String name, int age) {
        this.name = name;
        this.age = age;
    }

    public String getName() {
        return this.name;
    }

    public int getAge() {
        return this.age;
    }

    @Override
    public boolean equals(Object obj) {
        Human other = (Human) obj;
        return this.name.equals(other.getName());
    }

    @Override
    public int hashCode() {
        return this.name.hashCode() + this.age.hashCode();
    }

    @Override
    public int compareTo(Human other) {
        int compareResult  = this.name.compareTo(other.getName());
        if (compareResult == 0){
            compareResult = Integer.compare(this.age, other.getAge());
        }

        return compareResult;
    }
}
