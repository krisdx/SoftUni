package problem6_Animals;

public abstract class Animal {
    private String name;
    private int age;
    private String gender;

    protected Animal(String name, int age, String gender) {
        this.setName(name);
        this.setAge(age);
        this.setGender(gender);
    }

    public void produceSound() {
        System.out.println("Not implemented!");
    }

    @Override
    public String toString() {
        return String.format("%s%n %s %d %s",
                this.getClass().getSimpleName(), this.name, this.age, this.gender);
    }

    protected void setName(String name) {
        this.validateArgument(name);

        this.name = name;
    }

    protected void setAge(int age) {
        if (age <= 0) {
            throw new IllegalArgumentException("Invalid input!");
        }

        this.age = age;
    }

    protected void setGender(String gender) {
        this.validateArgument(gender);

        this.gender = gender;
    }

    private void validateArgument(String argument) {
        if (argument == null || argument.isEmpty()) {
            throw new IllegalArgumentException("Invalid input!");
        }
    }
}