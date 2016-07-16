package models;

public abstract class Component {
    private String name;

    protected Component(String name) {
        this.setName(name);
    }

    public String getName() {
        return this.name;
    }

    public abstract String getType();

    private void setName(String name) {
        if (name.isEmpty() || name.equals(" ")) {
            throw new IllegalArgumentException("The name cannot be empty.");
        }

        this.name = name;
    }
}